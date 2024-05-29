from flask import Blueprint, request, jsonify
from models import db, Profile
from flask_jwt_extended import jwt_required, get_jwt_identity

profile = Blueprint('profile', __name__)


@profile.route('/me', methods=['GET'])
@jwt_required()
def get_profile():
    jwt_identity = get_jwt_identity()
    id = jwt_identity.get('id')
    profile = Profile.query.filter_by(id=id).first()
    if not profile:
        return jsonify({"msg: Profile not found"})
    return jsonify({
        "name": profile.name,
        "mail": profile.mail,
        "pass": profile.password
    }), 200

@profile.route('/edit', methods=['GET', 'POST'])
@jwt_required()
def edit_profile():
    jwt_identity = get_jwt_identity()
    print(f"jwt_identity: {jwt_identity}")
    id = jwt_identity.get('id')
    print(f"id: {id}")
    profile = Profile.query.filter_by(id=id).first()
    print (f"profile: {profile}")
    
    if request.method == 'GET':
        if not profile:
            return jsonify({"msg": "Profile not found"})
        return jsonify({
            "name": profile.name,
            "mail": profile.mail,
            "pass": profile.password
        }), 200

    if request.method == 'POST':
        data = request.get_json()
        print(f"Received data: {data}")

        profile.name = data.get('name')
        profile.password = data.get('pass')
        profile.mail = data.get('mail')

        profile_data = {
            "name": profile.name,
            "mail": profile.mail,
            "pass": profile.password
        }
        print(f"Profile data before commit: {profile_data}")

        db.session.commit()

        print("Profile updated in database")

        return jsonify({"msg": "Profile updated"
        }), 200
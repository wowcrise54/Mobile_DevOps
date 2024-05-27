from flask import Blueprint, request, jsonify
from models import db, Profile
from flask_jwt_extended import jwt_required, get_jwt_identity

profile = Blueprint('profile', __name__)

@profile.route('/me', methods=['GET'])
@jwt_required()
def get_profile():
    jwt_identity = get_jwt_identity()
    mail = jwt_identity.get('mail')
    profile = Profile.query.filter_by(mail=mail).first()
    if not profile:
        return jsonify({"msg: Profile not found"})
    return jsonify({
        "name": profile.name,
        "mail": profile.mail
    }), 200
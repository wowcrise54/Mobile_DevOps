from flask import Blueprint, request, jsonify
from models import db, Profile
from flask_jwt_extended import create_access_token

auth = Blueprint('auth', __name__)


@auth.route('/register', methods=['POST'])
def register():
    data = request.get_json()
    name = data.get('name')
    mail = data.get('mail')
    password = data.get('password')
    if not name or not mail or not password:
        return jsonify({"msg": "Missing required parameters"}), 400

    if Profile.query.filter_by(mail=mail).first():
        return jsonify({"msg": "Email already exists"}), 400

    new_profile = Profile(name=name, mail=mail, password=password)
    db.session.add(new_profile)
    db.session.commit()

    return jsonify({"msg": "Profile created successfully"}), 201


@auth.route('/login', methods=['POST'])
def login():
    data = request.get_json()
    mail = data.get('mail')
    password = data.get('password')
    profile = Profile.query.filter_by(mail=mail).first()
    if profile and profile.password == password:
        access_token = create_access_token(identity={'id': profile.id})
        return jsonify(access_token=access_token), 200

    return jsonify({"msg": "Invalid email or password"}), 401
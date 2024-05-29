from flask import Flask, jsonify
from config import Config
from models import db
from auth.routes import auth
from profile.routes import profile
from flask_jwt_extended import JWTManager
import os

app = Flask(__name__)
app.config.from_object(Config)

db.init_app(app)
jwt = JWTManager(app)

app.register_blueprint(auth, url_prefix='/auth')
app.register_blueprint(profile, url_prefix='/profile')


if __name__ == '__main__':
    with app.app_context():
        db.create_all()
    app.run(host=os.getenv("HOST"), port=os.getenv("PORT"), debug=os.getenv("DEBUG"))

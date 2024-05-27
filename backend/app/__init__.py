from flask import Flask, render_template, url_for, request, flash
from flask_sqlalchemy import SQLAlchemy
from .config import Config

db = SQLAlchemy()

def create_app():
    app = Flask(__name__)
    app.config.from_object(Config)

    db.init_app(app)

    with app.app_context():
        from.import routes, models
        from .routes import main as main_blueprint
        app.register_blueprint(main_blueprint)
        return app
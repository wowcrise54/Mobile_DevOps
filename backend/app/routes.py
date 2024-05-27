from flask import Flask, Blueprint, render_template, flash, redirect, url_for
from . import db
from . models import User
from . forms import LoginForm
from.import create_app

main = Blueprint('main', __name__)

@main.route('/')
@main.route('/index')
def index():
    return render_template('index.html', title='Main')
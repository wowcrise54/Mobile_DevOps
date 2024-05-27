import os

basedir = os.path.abspath(os.path.dirname(__file__))

class Config:
    SQLALCHEMY_DATABASE_URI = 'mysql+pymysql://postgres:admin@localhost/mobile_ibas'
    SQLALCHEMY_TRACK_MODIFICATIONS = False
    SECRET_KEY ='11111111111111'

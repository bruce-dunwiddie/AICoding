from flask_wtf import FlaskForm
from wtforms import StringField, PasswordField, BooleanField, SubmitField
from wtforms.validators import DataRequired, Email, Length, EqualTo, ValidationError
from app.models.user import User

class LoginForm(FlaskForm):
    """Login form"""
    email = StringField('Email', validators=[DataRequired(), Email()])
    password = PasswordField('Password', validators=[DataRequired()])
    remember_me = BooleanField('Remember Me')
    submit = SubmitField('Sign In')

class RegistrationForm(FlaskForm):
    """Registration form"""
    username = StringField('Username', validators=[DataRequired(), Length(min=2, max=256)])
    email = StringField('Email', validators=[DataRequired(), Email(), Length(max=256)])
    password = PasswordField('Password', validators=[DataRequired(), Length(min=6)])
    password2 = PasswordField('Repeat Password', validators=[DataRequired(), EqualTo('password')])
    submit = SubmitField('Register')
    
    def validate_email(self, email):
        """Validate that email is not already registered"""
        user = User.query.filter_by(NormalizedEmail=email.data.upper()).first()
        if user is not None:
            raise ValidationError('Please use a different email address.')
            
    def validate_username(self, username):
        """Validate that username is not already taken"""
        user = User.query.filter_by(NormalizedUserName=username.data.upper()).first()
        if user is not None:
            raise ValidationError('Please use a different username.') 
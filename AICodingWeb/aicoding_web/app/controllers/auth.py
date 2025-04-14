from flask import Blueprint, render_template, redirect, url_for, flash, request
from flask_login import login_user, logout_user, login_required, current_user
from werkzeug.security import generate_password_hash, check_password_hash
from app import db
from app.models.user import User
from app.forms.auth import LoginForm, RegistrationForm
from datetime import datetime
import uuid

auth_bp = Blueprint('auth', __name__)

@auth_bp.route('/login', methods=['GET', 'POST'])
def login():
    """Login page"""
    if current_user.is_authenticated:
        return redirect(url_for('home.index'))
    
    form = LoginForm()
    if form.validate_on_submit():
        user = User.query.filter_by(NormalizedEmail=form.email.data.upper()).first()
        if user and user.check_password(form.password.data):
            login_user(user, remember=form.remember_me.data)
            next_page = request.args.get('next')
            return redirect(next_page or url_for('home.index'))
        flash('Invalid email or password', 'error')
    
    return render_template('auth/login.html', form=form)

@auth_bp.route('/logout')
@login_required
def logout():
    """Logout"""
    logout_user()
    return redirect(url_for('auth.login'))

@auth_bp.route('/register', methods=['GET', 'POST'])
def register():
    """Registration page"""
    if current_user.is_authenticated:
        return redirect(url_for('home.index'))
    
    form = RegistrationForm()
    if form.validate_on_submit():
        user = User(
            Id=str(uuid.uuid4()),
            UserName=form.username.data,
            NormalizedUserName=form.username.data.upper(),
            Email=form.email.data,
            NormalizedEmail=form.email.data.upper(),
            EmailConfirmed=False,
            SecurityStamp=str(uuid.uuid4()),
            ConcurrencyStamp=str(uuid.uuid4()),
            PhoneNumberConfirmed=False,
            TwoFactorEnabled=False,
            LockoutEnabled=True,
            AccessFailedCount=0
        )
        user.set_password(form.password.data)
        db.session.add(user)
        db.session.commit()
        flash('Registration successful', 'success')
        return redirect(url_for('auth.login'))
    
    return render_template('auth/register.html', form=form) 
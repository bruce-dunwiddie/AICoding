from flask import Blueprint, render_template
from flask_login import login_required

home_bp = Blueprint('home', __name__)

@home_bp.route('/')
@login_required
def index():
    """Home page"""
    return render_template('home/index.html')

@home_bp.route('/dashboard')
@login_required
def dashboard():
    """Dashboard page"""
    return render_template('home/dashboard.html') 
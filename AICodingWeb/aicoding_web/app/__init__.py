from flask import Flask
from flask_sqlalchemy import SQLAlchemy
from flask_login import LoginManager
from flask_migrate import Migrate
import os
from dotenv import load_dotenv

# Load environment variables
load_dotenv()

# Initialize extensions
db = SQLAlchemy()
login_manager = LoginManager()
migrate = Migrate()

def create_app(config_name=None):
    """Application factory function"""
    flask_app = Flask(__name__)
    
    # Configure the app
    if config_name is None:
        config_name = os.environ.get('FLASK_CONFIG', 'development')
    
    flask_app.config.from_object(f'app.config.{config_name.capitalize()}Config')
    
    # Initialize extensions with app
    db.init_app(flask_app)
    login_manager.init_app(flask_app)
    migrate.init_app(flask_app, db)
    
    # Set up login manager
    login_manager.login_view = 'auth.login'
    login_manager.login_message = 'Please log in to access this page.'
    
    # Register blueprints
    from app.controllers.home import home_bp
    from app.controllers.auth import auth_bp
    from app.controllers.shipping import shipping_bp
    from app.controllers.customer_service import customer_service_bp
    from app.controllers.reporting import reporting_bp
    
    flask_app.register_blueprint(home_bp)
    flask_app.register_blueprint(auth_bp)
    flask_app.register_blueprint(shipping_bp)
    flask_app.register_blueprint(customer_service_bp)
    flask_app.register_blueprint(reporting_bp)
    
    # Import models to ensure they are registered with SQLAlchemy
    import app.models
    
    return flask_app 
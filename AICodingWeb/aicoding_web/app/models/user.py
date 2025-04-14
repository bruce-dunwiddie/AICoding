from datetime import datetime
import uuid
from werkzeug.security import generate_password_hash, check_password_hash
from app import db, login_manager
from app.models.base import BaseModel
from flask_login import UserMixin

class User(db.Model, BaseModel, UserMixin):
    """User model"""
    
    __tablename__ = 'AspNetUsers'
    __table_args__ = {'schema': 'dbo'}
    
    Id = db.Column(db.String(450), primary_key=True)
    UserName = db.Column(db.String(256))
    NormalizedUserName = db.Column(db.String(256))
    Email = db.Column(db.String(256))
    NormalizedEmail = db.Column(db.String(256))
    EmailConfirmed = db.Column(db.Boolean, default=False)
    PasswordHash = db.Column(db.String(256))
    SecurityStamp = db.Column(db.String(256))
    ConcurrencyStamp = db.Column(db.String(256))
    PhoneNumber = db.Column(db.String(256))
    PhoneNumberConfirmed = db.Column(db.Boolean, default=False)
    TwoFactorEnabled = db.Column(db.Boolean, default=False)
    LockoutEnd = db.Column(db.DateTime)
    LockoutEnabled = db.Column(db.Boolean, default=False)
    AccessFailedCount = db.Column(db.Integer, default=0)
    
    def __repr__(self):
        return f'<User {self.UserName}>'
    
    def get_id(self):
        return str(self.Id)
    
    def set_password(self, password):
        """Set the password hash for this user using Werkzeug's security."""
        self.PasswordHash = generate_password_hash(password)
    
    def check_password(self, password):
        """Check if the provided password matches using Werkzeug's security."""
        if not self.PasswordHash:
            return False
        return check_password_hash(self.PasswordHash, password)

class Role(db.Model, BaseModel):
    """Role model for authorization"""
    
    __tablename__ = 'AspNetRoles'
    __table_args__ = {'schema': 'dbo'}
    
    Id = db.Column(db.String(450), primary_key=True)
    Name = db.Column(db.String(256))
    NormalizedName = db.Column(db.String(256))
    ConcurrencyStamp = db.Column(db.String(256))
    
    def __repr__(self):
        return f'<Role {self.Name}>'

# Association table for user-role relationship
user_roles = db.Table('AspNetUserRoles',
    db.Column('UserId', db.String(450), db.ForeignKey('dbo.AspNetUsers.Id'), primary_key=True),
    db.Column('RoleId', db.String(450), db.ForeignKey('dbo.AspNetRoles.Id'), primary_key=True),
    schema='dbo'
)

@login_manager.user_loader
def load_user(user_id):
    """Load a user by ID for Flask-Login"""
    return User.query.get(user_id) 
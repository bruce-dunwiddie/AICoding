from datetime import datetime
from app import db
from app.models.base import BaseModel

class UserRole(db.Model, BaseModel):
    """User role junction model"""
    
    __tablename__ = 'user_roles'
    
    id = db.Column(db.Integer, primary_key=True)
    user_id = db.Column(db.Integer, db.ForeignKey('users.id'), nullable=False)
    role_id = db.Column(db.Integer, db.ForeignKey('roles.id'), nullable=False)
    last_edited_by = db.Column(db.Integer, db.ForeignKey('people.id'), nullable=False)
    last_edited_when = db.Column(db.DateTime, nullable=False)
    
    # Relationships
    user = db.relationship('User', backref='user_roles')
    role = db.relationship('Role', backref='user_roles')
    last_edited_by_person = db.relationship('Person', foreign_keys=[last_edited_by], backref='edited_user_roles')
    
    def __repr__(self):
        return f'<UserRole {self.id}>' 
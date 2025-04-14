from datetime import datetime
from app import db
from app.models.base import BaseModel

class Role(db.Model, BaseModel):
    """Role model"""
    
    __tablename__ = 'roles'
    
    RoleID = db.Column(db.Integer, primary_key=True)
    RoleName = db.Column(db.String(50), unique=True, nullable=False)
    Description = db.Column(db.String(200))
    LastEditedBy = db.Column(db.Integer, db.ForeignKey('people.PersonID'), nullable=False)
    ValidFrom = db.Column(db.DateTime, nullable=False)
    ValidTo = db.Column(db.DateTime, nullable=False)
    
    def __repr__(self):
        return f'<Role {self.RoleName}>' 
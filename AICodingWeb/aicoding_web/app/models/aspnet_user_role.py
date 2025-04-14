from datetime import datetime
from app import db
from app.models.base import BaseModel

class AspNetUserRole(db.Model, BaseModel):
    """AspNetUserRole model for ASP.NET Identity"""
    
    __tablename__ = 'AspNetUserRoles'
    
    UserId = db.Column(db.String(450), db.ForeignKey('AspNetUsers.Id'), primary_key=True)
    RoleId = db.Column(db.String(450), db.ForeignKey('AspNetRoles.Id'), primary_key=True)
    
    def __repr__(self):
        return f'<AspNetUserRole {self.UserId}:{self.RoleId}>' 
from datetime import datetime
from app import db
from app.models.base import BaseModel

class AspNetRoleClaim(db.Model, BaseModel):
    """AspNetRoleClaim model for ASP.NET Identity"""
    
    __tablename__ = 'AspNetRoleClaims'
    
    Id = db.Column(db.Integer, primary_key=True)
    RoleId = db.Column(db.String(450), db.ForeignKey('AspNetRoles.Id'), nullable=False)
    ClaimType = db.Column(db.String)
    ClaimValue = db.Column(db.String)
    
    def __repr__(self):
        return f'<AspNetRoleClaim {self.Id}>' 
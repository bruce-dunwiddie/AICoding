from datetime import datetime
from app import db
from app.models.base import BaseModel

class AspNetUserClaim(db.Model, BaseModel):
    """AspNetUserClaim model for ASP.NET Identity"""
    
    __tablename__ = 'AspNetUserClaims'
    
    Id = db.Column(db.Integer, primary_key=True)
    UserId = db.Column(db.String(450), db.ForeignKey('AspNetUsers.Id'), nullable=False)
    ClaimType = db.Column(db.String)
    ClaimValue = db.Column(db.String)
    
    def __repr__(self):
        return f'<AspNetUserClaim {self.Id}>' 
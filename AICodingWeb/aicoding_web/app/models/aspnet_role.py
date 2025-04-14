from datetime import datetime
from app import db
from app.models.base import BaseModel

class AspNetRole(db.Model, BaseModel):
    """AspNetRole model for ASP.NET Identity"""
    
    __tablename__ = 'AspNetRoles'
    
    Id = db.Column(db.String(450), primary_key=True)
    Name = db.Column(db.String(256))
    NormalizedName = db.Column(db.String(256))
    ConcurrencyStamp = db.Column(db.String)
    
    def __repr__(self):
        return f'<AspNetRole {self.Id}>' 
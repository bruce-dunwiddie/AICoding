from datetime import datetime
from app import db
from app.models.base import BaseModel

class AspNetUser(db.Model, BaseModel):
    """AspNetUser model for ASP.NET Identity"""
    
    __tablename__ = 'AspNetUsers'
    
    Id = db.Column(db.String(450), primary_key=True)
    UserName = db.Column(db.String(256))
    NormalizedUserName = db.Column(db.String(256))
    Email = db.Column(db.String(256))
    NormalizedEmail = db.Column(db.String(256))
    EmailConfirmed = db.Column(db.Boolean, nullable=False)
    PasswordHash = db.Column(db.String)
    SecurityStamp = db.Column(db.String)
    ConcurrencyStamp = db.Column(db.String)
    PhoneNumber = db.Column(db.String)
    PhoneNumberConfirmed = db.Column(db.Boolean, nullable=False)
    TwoFactorEnabled = db.Column(db.Boolean, nullable=False)
    LockoutEnd = db.Column(db.DateTime)
    LockoutEnabled = db.Column(db.Boolean, nullable=False)
    AccessFailedCount = db.Column(db.Integer, nullable=False)
    
    def __repr__(self):
        return f'<AspNetUser {self.Id}>' 
from datetime import datetime
from app import db
from app.models.base import BaseModel

class AspNetUserLogin(db.Model, BaseModel):
    """AspNetUserLogin model for ASP.NET Identity"""
    
    __tablename__ = 'AspNetUserLogins'
    
    LoginProvider = db.Column(db.String(450), primary_key=True)
    ProviderKey = db.Column(db.String(450), primary_key=True)
    ProviderDisplayName = db.Column(db.String)
    UserId = db.Column(db.String(450), db.ForeignKey('AspNetUsers.Id'), nullable=False)
    
    def __repr__(self):
        return f'<AspNetUserLogin {self.LoginProvider}:{self.ProviderKey}>' 
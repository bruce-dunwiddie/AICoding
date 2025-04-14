from datetime import datetime
from app import db
from app.models.base import BaseModel

class AspNetUserToken(db.Model, BaseModel):
    """AspNetUserToken model for ASP.NET Identity"""
    
    __tablename__ = 'AspNetUserTokens'
    
    UserId = db.Column(db.String(450), db.ForeignKey('AspNetUsers.Id'), primary_key=True)
    LoginProvider = db.Column(db.String(450), primary_key=True)
    Name = db.Column(db.String(450), primary_key=True)
    Value = db.Column(db.String)
    
    def __repr__(self):
        return f'<AspNetUserToken {self.UserId}:{self.LoginProvider}:{self.Name}>' 
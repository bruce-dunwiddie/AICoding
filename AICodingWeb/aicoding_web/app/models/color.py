from datetime import datetime
from app import db
from app.models.base import BaseModel

class Color(db.Model, BaseModel):
    """Color model"""
    
    __tablename__ = 'colors'
    
    ColorID = db.Column(db.Integer, primary_key=True)
    ColorName = db.Column(db.String(20), nullable=False)
    LastEditedBy = db.Column(db.Integer, db.ForeignKey('people.PersonID'), nullable=False)
    ValidFrom = db.Column(db.DateTime, nullable=False)
    ValidTo = db.Column(db.DateTime, nullable=False)
    
    def __repr__(self):
        return f'<Color {self.ColorID}>' 
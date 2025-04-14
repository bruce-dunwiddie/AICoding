from datetime import datetime
from app import db
from app.models.base import BaseModel

class DeliveryMethod(db.Model, BaseModel):
    """DeliveryMethod model"""
    
    __tablename__ = 'delivery_methods'
    
    DeliveryMethodID = db.Column(db.Integer, primary_key=True)
    DeliveryMethodName = db.Column(db.String(50), nullable=False)
    LastEditedBy = db.Column(db.Integer, db.ForeignKey('people.PersonID'), nullable=False)
    ValidFrom = db.Column(db.DateTime, nullable=False)
    ValidTo = db.Column(db.DateTime, nullable=False)
    
    def __repr__(self):
        return f'<DeliveryMethod {self.DeliveryMethodID}>' 
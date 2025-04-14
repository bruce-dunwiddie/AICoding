from datetime import datetime
from app import db
from app.models.base import BaseModel

class PaymentMethod(db.Model, BaseModel):
    """PaymentMethod model"""
    
    __tablename__ = 'payment_methods'
    
    PaymentMethodID = db.Column(db.Integer, primary_key=True)
    PaymentMethodName = db.Column(db.String(50), nullable=False)
    LastEditedBy = db.Column(db.Integer, db.ForeignKey('people.PersonID'), nullable=False)
    ValidFrom = db.Column(db.DateTime, nullable=False)
    ValidTo = db.Column(db.DateTime, nullable=False)
    
    def __repr__(self):
        return f'<PaymentMethod {self.PaymentMethodID}>' 
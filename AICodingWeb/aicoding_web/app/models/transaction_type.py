from datetime import datetime
from app import db
from app.models.base import BaseModel

class TransactionType(db.Model, BaseModel):
    """TransactionType model"""
    
    __tablename__ = 'transaction_types'
    
    TransactionTypeID = db.Column(db.Integer, primary_key=True)
    TransactionTypeName = db.Column(db.String(50), nullable=False)
    LastEditedBy = db.Column(db.Integer, db.ForeignKey('people.PersonID'), nullable=False)
    ValidFrom = db.Column(db.DateTime, nullable=False)
    ValidTo = db.Column(db.DateTime, nullable=False)
    
    def __repr__(self):
        return f'<TransactionType {self.TransactionTypeID}>' 
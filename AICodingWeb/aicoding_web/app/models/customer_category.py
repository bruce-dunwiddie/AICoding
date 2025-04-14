from datetime import datetime
from app import db
from app.models.base import BaseModel

class CustomerCategory(db.Model, BaseModel):
    """CustomerCategory model"""
    
    __tablename__ = 'customer_categories'
    
    CustomerCategoryID = db.Column(db.Integer, primary_key=True)
    CustomerCategoryName = db.Column(db.String(50), nullable=False)
    LastEditedBy = db.Column(db.Integer, db.ForeignKey('people.PersonID'), nullable=False)
    ValidFrom = db.Column(db.DateTime, nullable=False)
    ValidTo = db.Column(db.DateTime, nullable=False)
    
    def __repr__(self):
        return f'<CustomerCategory {self.CustomerCategoryID}>' 
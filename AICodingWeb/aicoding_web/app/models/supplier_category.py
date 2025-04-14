from datetime import datetime
from app import db
from app.models.base import BaseModel

class SupplierCategory(db.Model, BaseModel):
    """SupplierCategory model"""
    
    __tablename__ = 'supplier_categories'
    
    SupplierCategoryID = db.Column(db.Integer, primary_key=True)
    SupplierCategoryName = db.Column(db.String(50), nullable=False)
    LastEditedBy = db.Column(db.Integer, db.ForeignKey('people.PersonID'), nullable=False)
    ValidFrom = db.Column(db.DateTime, nullable=False)
    ValidTo = db.Column(db.DateTime, nullable=False)
    
    def __repr__(self):
        return f'<SupplierCategory {self.SupplierCategoryID}>' 
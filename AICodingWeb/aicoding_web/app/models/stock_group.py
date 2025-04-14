from datetime import datetime
from app import db
from app.models.base import BaseModel

class StockGroup(db.Model, BaseModel):
    """StockGroup model"""
    
    __tablename__ = 'stock_groups'
    
    StockGroupID = db.Column(db.Integer, primary_key=True)
    StockGroupName = db.Column(db.String(50), nullable=False)
    LastEditedBy = db.Column(db.Integer, db.ForeignKey('people.PersonID'), nullable=False)
    ValidFrom = db.Column(db.DateTime, nullable=False)
    ValidTo = db.Column(db.DateTime, nullable=False)
    
    def __repr__(self):
        return f'<StockGroup {self.StockGroupID}>' 
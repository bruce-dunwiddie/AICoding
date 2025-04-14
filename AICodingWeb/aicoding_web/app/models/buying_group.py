from datetime import datetime
from app import db
from app.models.base import BaseModel

class BuyingGroup(db.Model, BaseModel):
    """BuyingGroup model"""
    
    __tablename__ = 'buying_groups'
    
    BuyingGroupID = db.Column(db.Integer, primary_key=True)
    BuyingGroupName = db.Column(db.String(50), nullable=False)
    LastEditedBy = db.Column(db.Integer, db.ForeignKey('people.PersonID'), nullable=False)
    ValidFrom = db.Column(db.DateTime, nullable=False)
    ValidTo = db.Column(db.DateTime, nullable=False)
    
    def __repr__(self):
        return f'<BuyingGroup {self.BuyingGroupID}>' 
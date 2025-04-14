from datetime import datetime
from app import db
from app.models.base import BaseModel

class PackageType(db.Model, BaseModel):
    """PackageType model"""
    
    __tablename__ = 'package_types'
    
    PackageTypeID = db.Column(db.Integer, primary_key=True)
    PackageTypeName = db.Column(db.String(50), nullable=False)
    LastEditedBy = db.Column(db.Integer, db.ForeignKey('people.PersonID'), nullable=False)
    ValidFrom = db.Column(db.DateTime, nullable=False)
    ValidTo = db.Column(db.DateTime, nullable=False)
    
    def __repr__(self):
        return f'<PackageType {self.PackageTypeID}>' 
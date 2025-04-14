from datetime import datetime
from app import db
from app.models.base import BaseModel
from sqlalchemy.orm import deferred

class StateProvince(db.Model, BaseModel):
    """StateProvince model"""
    
    __tablename__ = 'StateProvinces'
    __table_args__ = {'schema': 'Application'}
    
    StateProvinceID = db.Column(db.Integer, primary_key=True)
    StateProvinceCode = db.Column(db.String(5), nullable=False)
    StateProvinceName = db.Column(db.String(50), nullable=False)
    CountryID = db.Column(db.Integer, db.ForeignKey('Application.Countries.CountryID'), nullable=False)
    SalesTerritory = db.Column(db.String(50), nullable=False)
    Border = deferred(db.Column(db.String))  # Deferred loading for geography column
    LatestRecordedPopulation = db.Column(db.BigInteger)
    LastEditedBy = db.Column(db.Integer, db.ForeignKey('Application.People.PersonID'), nullable=False)
    ValidFrom = db.Column(db.DateTime, nullable=False)
    ValidTo = db.Column(db.DateTime, nullable=False)
    
    def __repr__(self):
        return f'<StateProvince {self.StateProvinceID}>' 
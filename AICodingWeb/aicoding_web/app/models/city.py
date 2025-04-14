from datetime import datetime
from app import db
from app.models.base import BaseModel
from app.models.custom_types import Geography

class City(db.Model, BaseModel):
    """City model"""
    
    __tablename__ = 'Cities'
    __table_args__ = {'schema': 'Application'}
    
    CityID = db.Column(db.Integer, primary_key=True)
    CityName = db.Column(db.String(50), nullable=False)
    StateProvinceID = db.Column(db.Integer, db.ForeignKey('Application.StateProvinces.StateProvinceID'), nullable=False)
    Location = db.Column(Geography)
    LatestRecordedPopulation = db.Column(db.BigInteger)
    LastEditedBy = db.Column(db.Integer, db.ForeignKey('Application.People.PersonID'), nullable=False)
    ValidFrom = db.Column(db.DateTime, nullable=False)
    ValidTo = db.Column(db.DateTime, nullable=False)
    
    def __repr__(self):
        return f'<City {self.CityID}>' 
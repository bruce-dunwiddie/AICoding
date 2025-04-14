from datetime import datetime
from app import db
from app.models.base import BaseModel
from sqlalchemy.orm import deferred

class Country(db.Model, BaseModel):
    """Country model"""
    
    __tablename__ = 'Countries'
    __table_args__ = {'schema': 'Application'}
    
    CountryID = db.Column(db.Integer, primary_key=True)
    CountryName = db.Column(db.String(60), nullable=False)
    FormalName = db.Column(db.String(60), nullable=False)
    IsoAlpha3Code = db.Column(db.String(3))
    IsoNumericCode = db.Column(db.Integer)
    CountryType = db.Column(db.String(20))
    LatestRecordedPopulation = db.Column(db.BigInteger)
    Continent = db.Column(db.String(30), nullable=False)
    Region = db.Column(db.String(30), nullable=False)
    Subregion = db.Column(db.String(30), nullable=False)
    Border = deferred(db.Column(db.String))  # Deferred loading for geography column
    LastEditedBy = db.Column(db.Integer, db.ForeignKey('Application.People.PersonID'), nullable=False)
    ValidFrom = db.Column(db.DateTime, nullable=False)
    ValidTo = db.Column(db.DateTime, nullable=False)
    
    def __repr__(self):
        return f'<Country {self.CountryID}>' 
from datetime import datetime
from app import db
from app.models.base import BaseModel

class SystemParameter(db.Model, BaseModel):
    """System parameter model"""
    
    __tablename__ = 'system_parameters'
    
    SystemParameterID = db.Column(db.Integer, primary_key=True)
    DeliveryAddressLine1 = db.Column(db.String(60), nullable=False)
    DeliveryAddressLine2 = db.Column(db.String(60))
    DeliveryCityID = db.Column(db.Integer, db.ForeignKey('cities.CityID'), nullable=False)
    DeliveryPostalCode = db.Column(db.String(10), nullable=False)
    DeliveryLocation = db.Column(db.JSON, nullable=False)
    PostalAddressLine1 = db.Column(db.String(60), nullable=False)
    PostalAddressLine2 = db.Column(db.String(60))
    PostalCityID = db.Column(db.Integer, db.ForeignKey('cities.CityID'), nullable=False)
    PostalPostalCode = db.Column(db.String(10), nullable=False)
    ApplicationSettings = db.Column(db.JSON, nullable=False)
    LastEditedBy = db.Column(db.Integer, db.ForeignKey('people.PersonID'), nullable=False)
    LastEditedWhen = db.Column(db.DateTime, nullable=False)
    
    def __repr__(self):
        return f'<SystemParameter {self.SystemParameterID}>' 
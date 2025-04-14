from datetime import datetime
from app import db
from app.models.base import BaseModel

class VehicleTemperature(db.Model, BaseModel):
    """Vehicle temperature model"""
    
    __tablename__ = 'vehicle_temperatures'
    
    VehicleTemperatureID = db.Column(db.Integer, primary_key=True)
    VehicleRegistration = db.Column(db.String(20), nullable=False)
    ChillerSensorNumber = db.Column(db.Integer, nullable=False)
    RecordedWhen = db.Column(db.DateTime, nullable=False)
    Temperature = db.Column(db.Float, nullable=False)
    FullSensorData = db.Column(db.String(1000))
    IsCompressed = db.Column(db.Boolean, nullable=False)
    CompressedSensorData = db.Column(db.LargeBinary)
    
    def __repr__(self):
        return f'<VehicleTemperature {self.VehicleTemperatureID}>' 
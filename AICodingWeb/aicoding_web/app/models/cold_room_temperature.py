from datetime import datetime
from app import db
from app.models.base import BaseModel

class ColdRoomTemperature(db.Model, BaseModel):
    """Cold room temperature model"""
    
    __tablename__ = 'cold_room_temperatures'
    
    id = db.Column(db.Integer, primary_key=True)
    cold_room_sensor_number = db.Column(db.Integer, nullable=False)
    recorded_when = db.Column(db.DateTime, nullable=False)
    temperature = db.Column(db.Numeric(10, 2), nullable=False)
    valid_from = db.Column(db.DateTime, nullable=False, default=datetime.utcnow)
    valid_to = db.Column(db.DateTime, nullable=False, default=datetime.utcnow)
    
    def __repr__(self):
        return f'<ColdRoomTemperature {self.id}>' 
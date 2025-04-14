from datetime import datetime
from app import db

class BaseModel:
    """Base model class with common fields and methods"""
    
    def save(self):
        """Save the model to the database"""
        db.session.add(self)
        db.session.commit()
        
    def delete(self):
        """Delete the model from the database"""
        db.session.delete(self)
        db.session.commit()
        
    @classmethod
    def get_by_id(cls, id):
        """Get a model by ID"""
        return cls.query.get(id)
        
    @classmethod
    def get_all(cls):
        """Get all models"""
        return cls.query.all() 
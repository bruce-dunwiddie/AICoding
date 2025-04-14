from datetime import datetime
from app import db
from app.models.base import BaseModel

class Person(db.Model, BaseModel):
    """Person model"""
    
    __tablename__ = 'People'
    __table_args__ = {'schema': 'Application'}
    
    PersonID = db.Column(db.Integer, primary_key=True)
    FullName = db.Column(db.String(50), nullable=False)
    PreferredName = db.Column(db.String(50), nullable=False)
    SearchName = db.Column(db.String(101), nullable=False)
    IsPermittedToLogon = db.Column(db.Boolean, nullable=False)
    LogonName = db.Column(db.String(50))
    IsExternalLogonProvider = db.Column(db.Boolean, nullable=False)
    HashedPassword = db.Column(db.String(50))
    IsSystemUser = db.Column(db.Boolean, nullable=False)
    IsEmployee = db.Column(db.Boolean, nullable=False)
    IsSalesperson = db.Column(db.Boolean, nullable=False)
    UserPreferences = db.Column(db.JSON)
    PhoneNumber = db.Column(db.String(20))
    FaxNumber = db.Column(db.String(20))
    EmailAddress = db.Column(db.String(256))
    Photo = db.Column(db.LargeBinary)
    CustomFields = db.Column(db.JSON)
    OtherLanguages = db.Column(db.JSON)
    LastEditedBy = db.Column(db.Integer, db.ForeignKey('Application.People.PersonID'), nullable=False)
    ValidFrom = db.Column(db.DateTime, nullable=False)
    ValidTo = db.Column(db.DateTime, nullable=False)
    
    def __repr__(self):
        return f'<Person {self.PersonID}>' 
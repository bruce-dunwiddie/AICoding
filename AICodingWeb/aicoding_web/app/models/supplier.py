from datetime import datetime
from app import db
from app.models.base import BaseModel
from app.models.custom_types import Geography
from sqlalchemy.orm import deferred

class Supplier(db.Model, BaseModel):
    """Supplier model"""
    
    __tablename__ = 'Suppliers'
    __table_args__ = {'schema': 'Purchasing'}
    
    SupplierID = db.Column(db.Integer, primary_key=True)
    SupplierName = db.Column(db.String(100), nullable=False)
    SupplierCategoryID = db.Column(db.Integer, db.ForeignKey('Purchasing.SupplierCategories.SupplierCategoryID'), nullable=False)
    PrimaryContactPersonID = db.Column(db.Integer, db.ForeignKey('Application.People.PersonID'), nullable=False)
    AlternateContactPersonID = db.Column(db.Integer, db.ForeignKey('Application.People.PersonID'))
    DeliveryMethodID = db.Column(db.Integer, db.ForeignKey('Application.DeliveryMethods.DeliveryMethodID'))
    DeliveryCityID = db.Column(db.Integer, db.ForeignKey('Application.Cities.CityID'), nullable=False)
    PostalCityID = db.Column(db.Integer, db.ForeignKey('Application.Cities.CityID'), nullable=False)
    SupplierReference = db.Column(db.String(20))
    PaymentDays = db.Column(db.Integer, nullable=False)
    PostalCode = db.Column(db.String(10), nullable=False)
    PhoneNumber = db.Column(db.String(20), nullable=False)
    FaxNumber = db.Column(db.String(20), nullable=False)
    WebsiteURL = db.Column(db.String(256), nullable=False)
    DeliveryAddressLine1 = db.Column(db.String(60), nullable=False)
    DeliveryAddressLine2 = db.Column(db.String(60))
    DeliveryPostalCode = db.Column(db.String(10), nullable=False)
    DeliveryLocation = deferred(db.Column(db.String))  # Deferred loading for geography column
    PostalAddressLine1 = db.Column(db.String(60), nullable=False)
    PostalAddressLine2 = db.Column(db.String(60))
    PostalPostalCode = db.Column(db.String(10), nullable=False)
    LastEditedBy = db.Column(db.Integer, db.ForeignKey('Application.People.PersonID'), nullable=False)
    ValidFrom = db.Column(db.DateTime, nullable=False)
    ValidTo = db.Column(db.DateTime, nullable=False)
    
    def __repr__(self):
        return f'<Supplier {self.SupplierID}>' 
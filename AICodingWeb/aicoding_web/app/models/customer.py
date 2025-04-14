from datetime import datetime
from app import db
from app.models.base import BaseModel
from sqlalchemy.orm import deferred

class Customer(db.Model, BaseModel):
    """Customer model"""
    
    __tablename__ = 'Customers'
    __table_args__ = {'schema': 'Sales'}
    
    CustomerID = db.Column(db.Integer, primary_key=True)
    CustomerName = db.Column(db.String(100), nullable=False)
    BillToCustomerID = db.Column(db.Integer, db.ForeignKey('Sales.Customers.CustomerID'), nullable=False)
    CustomerCategoryID = db.Column(db.Integer, db.ForeignKey('Sales.CustomerCategories.CustomerCategoryID'), nullable=False)
    BuyingGroupID = db.Column(db.Integer, db.ForeignKey('Sales.BuyingGroups.BuyingGroupID'))
    PrimaryContactPersonID = db.Column(db.Integer, db.ForeignKey('Application.People.PersonID'), nullable=False)
    AlternateContactPersonID = db.Column(db.Integer, db.ForeignKey('Application.People.PersonID'))
    DeliveryMethodID = db.Column(db.Integer, db.ForeignKey('Application.DeliveryMethods.DeliveryMethodID'), nullable=False)
    DeliveryCityID = db.Column(db.Integer, db.ForeignKey('Application.Cities.CityID'), nullable=False)
    PostalCityID = db.Column(db.Integer, db.ForeignKey('Application.Cities.CityID'), nullable=False)
    CreditLimit = db.Column(db.Numeric(18, 2))
    AccountOpenedDate = db.Column(db.Date, nullable=False)
    StandardDiscountPercentage = db.Column(db.Numeric(18, 3), nullable=False)
    IsStatementSent = db.Column(db.Boolean, nullable=False)
    IsOnCreditHold = db.Column(db.Boolean, nullable=False)
    PaymentDays = db.Column(db.Integer, nullable=False)
    PhoneNumber = db.Column(db.String(20), nullable=False)
    FaxNumber = db.Column(db.String(20), nullable=False)
    DeliveryRun = db.Column(db.String(5))
    RunPosition = db.Column(db.String(5))
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
        return f'<Customer {self.CustomerID}>' 
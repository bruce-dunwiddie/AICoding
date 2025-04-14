from datetime import datetime
from app import db
from app.models.base import BaseModel

class Order(db.Model, BaseModel):
    """Order model"""
    
    __tablename__ = 'Orders'
    __table_args__ = {'schema': 'Sales'}
    
    OrderID = db.Column(db.Integer, primary_key=True)
    CustomerID = db.Column(db.Integer, db.ForeignKey('Sales.Customers.CustomerID'), nullable=False)
    SalespersonPersonID = db.Column(db.Integer, db.ForeignKey('Application.People.PersonID'), nullable=False)
    PickedByPersonID = db.Column(db.Integer, db.ForeignKey('Application.People.PersonID'))
    ContactPersonID = db.Column(db.Integer, db.ForeignKey('Application.People.PersonID'), nullable=False)
    BackorderOrderID = db.Column(db.Integer, db.ForeignKey('Sales.Orders.OrderID'))
    OrderDate = db.Column(db.Date, nullable=False)
    ExpectedDeliveryDate = db.Column(db.Date)
    CustomerPurchaseOrderNumber = db.Column(db.String(20))
    IsUndersupplyBackordered = db.Column(db.Boolean, nullable=False)
    Comments = db.Column(db.Text)
    DeliveryInstructions = db.Column(db.Text)
    InternalComments = db.Column(db.Text)
    PickingCompletedWhen = db.Column(db.DateTime)
    LastEditedBy = db.Column(db.Integer, db.ForeignKey('Application.People.PersonID'), nullable=False)
    LastEditedWhen = db.Column(db.DateTime, nullable=False)
    
    def __repr__(self):
        return f'<Order {self.OrderID}>'

class OrderLine(db.Model, BaseModel):
    """OrderLine model"""
    
    __tablename__ = 'OrderLines'
    __table_args__ = {'schema': 'Sales'}
    
    OrderLineID = db.Column(db.Integer, primary_key=True)
    OrderID = db.Column(db.Integer, db.ForeignKey('Sales.Orders.OrderID'), nullable=False)
    StockItemID = db.Column(db.Integer, db.ForeignKey('Warehouse.StockItems.StockItemID'), nullable=False)
    Description = db.Column(db.String(100), nullable=False)
    PackageTypeID = db.Column(db.Integer, db.ForeignKey('Warehouse.PackageTypes.PackageTypeID'), nullable=False)
    Quantity = db.Column(db.Integer, nullable=False)
    UnitPrice = db.Column(db.Numeric(18, 2), nullable=False)
    TaxRate = db.Column(db.Numeric(18, 3), nullable=False)
    QuantityPicked = db.Column(db.Integer, nullable=False)
    PickingCompletedWhen = db.Column(db.DateTime)
    LastEditedBy = db.Column(db.Integer, db.ForeignKey('Application.People.PersonID'), nullable=False)
    LastEditedWhen = db.Column(db.DateTime, nullable=False)
    
    def __repr__(self):
        return f'<OrderLine {self.OrderLineID}>' 
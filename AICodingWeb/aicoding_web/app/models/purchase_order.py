from datetime import datetime
from app import db
from app.models.base import BaseModel

class PurchaseOrder(db.Model, BaseModel):
    """PurchaseOrder model"""
    
    __tablename__ = 'Purchasing.PurchaseOrders'
    
    PurchaseOrderID = db.Column(db.Integer, primary_key=True)
    SupplierID = db.Column(db.Integer, db.ForeignKey('suppliers.SupplierID'), nullable=False)
    OrderDate = db.Column(db.Date, nullable=False)
    DeliveryMethodID = db.Column(db.Integer, db.ForeignKey('delivery_methods.DeliveryMethodID'), nullable=False)
    ContactPersonID = db.Column(db.Integer, db.ForeignKey('people.PersonID'), nullable=False)
    ExpectedDeliveryDate = db.Column(db.Date)
    SupplierReference = db.Column(db.String(20))
    IsOrderFinalized = db.Column(db.Boolean, nullable=False)
    Comments = db.Column(db.Text)
    InternalComments = db.Column(db.Text)
    LastEditedBy = db.Column(db.Integer, db.ForeignKey('people.PersonID'), nullable=False)
    LastEditedWhen = db.Column(db.DateTime, nullable=False)
    
    def __repr__(self):
        return f'<PurchaseOrder {self.PurchaseOrderID}>'

class PurchaseOrderLine(db.Model, BaseModel):
    """PurchaseOrderLine model"""
    
    __tablename__ = 'Purchasing.PurchaseOrderLines'
    
    PurchaseOrderLineID = db.Column(db.Integer, primary_key=True)
    PurchaseOrderID = db.Column(db.Integer, db.ForeignKey('purchase_orders.PurchaseOrderID'), nullable=False)
    StockItemID = db.Column(db.Integer, db.ForeignKey('stock_items.StockItemID'), nullable=False)
    OrderedOuters = db.Column(db.Integer, nullable=False)
    Description = db.Column(db.String(100), nullable=False)
    ExpectedUnitPricePerOuter = db.Column(db.Numeric(18, 2), nullable=False)
    ReceivedOuters = db.Column(db.Integer, nullable=False)
    PackageTypeID = db.Column(db.Integer, db.ForeignKey('package_types.PackageTypeID'), nullable=False)
    LastEditedBy = db.Column(db.Integer, db.ForeignKey('people.PersonID'), nullable=False)
    LastEditedWhen = db.Column(db.DateTime, nullable=False)
    
    def __repr__(self):
        return f'<PurchaseOrderLine {self.PurchaseOrderLineID}>' 
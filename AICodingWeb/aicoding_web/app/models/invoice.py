from datetime import datetime
from app import db
from app.models.base import BaseModel

class Invoice(db.Model, BaseModel):
    """Invoice model"""
    
    __tablename__ = 'Invoices'
    __table_args__ = {'schema': 'Sales'}
    
    InvoiceID = db.Column(db.Integer, primary_key=True)
    CustomerID = db.Column(db.Integer, db.ForeignKey('Sales.Customers.CustomerID'), nullable=False)
    BillToCustomerID = db.Column(db.Integer, db.ForeignKey('Sales.Customers.CustomerID'), nullable=False)
    OrderID = db.Column(db.Integer, db.ForeignKey('Sales.Orders.OrderID'))
    DeliveryMethodID = db.Column(db.Integer, db.ForeignKey('Application.DeliveryMethods.DeliveryMethodID'), nullable=False)
    ContactPersonID = db.Column(db.Integer, db.ForeignKey('Application.People.PersonID'), nullable=False)
    AccountsPersonID = db.Column(db.Integer, db.ForeignKey('Application.People.PersonID'), nullable=False)
    SalespersonPersonID = db.Column(db.Integer, db.ForeignKey('Application.People.PersonID'), nullable=False)
    PackedByPersonID = db.Column(db.Integer, db.ForeignKey('Application.People.PersonID'), nullable=False)
    InvoiceDate = db.Column(db.Date, nullable=False)
    CustomerPurchaseOrderNumber = db.Column(db.String(20))
    IsCreditNote = db.Column(db.Boolean, nullable=False)
    CreditNoteReason = db.Column(db.Text)
    Comments = db.Column(db.Text)
    DeliveryInstructions = db.Column(db.Text)
    InternalComments = db.Column(db.Text)
    TotalDryItems = db.Column(db.Integer, nullable=False)
    TotalChillerItems = db.Column(db.Integer, nullable=False)
    DeliveryRun = db.Column(db.String(5))
    RunPosition = db.Column(db.String(5))
    ReturnedDeliveryData = db.Column(db.JSON)
    ConfirmedDeliveryTime = db.Column(db.DateTime)
    ConfirmedReceivedBy = db.Column(db.String(100))
    LastEditedBy = db.Column(db.Integer, db.ForeignKey('Application.People.PersonID'), nullable=False)
    LastEditedWhen = db.Column(db.DateTime, nullable=False)
    
    def __repr__(self):
        return f'<Invoice {self.InvoiceID}>'

class InvoiceLine(db.Model, BaseModel):
    """InvoiceLine model"""
    
    __tablename__ = 'InvoiceLines'
    __table_args__ = {'schema': 'Sales'}
    
    InvoiceLineID = db.Column(db.Integer, primary_key=True)
    InvoiceID = db.Column(db.Integer, db.ForeignKey('Sales.Invoices.InvoiceID'), nullable=False)
    StockItemID = db.Column(db.Integer, db.ForeignKey('Warehouse.StockItems.StockItemID'), nullable=False)
    Description = db.Column(db.String(100), nullable=False)
    PackageTypeID = db.Column(db.Integer, db.ForeignKey('Warehouse.PackageTypes.PackageTypeID'), nullable=False)
    Quantity = db.Column(db.Integer, nullable=False)
    UnitPrice = db.Column(db.Numeric(18, 2), nullable=False)
    TaxRate = db.Column(db.Numeric(18, 3), nullable=False)
    TaxAmount = db.Column(db.Numeric(18, 2), nullable=False)
    LineProfit = db.Column(db.Numeric(18, 2), nullable=False)
    ExtendedPrice = db.Column(db.Numeric(18, 2), nullable=False)
    LastEditedBy = db.Column(db.Integer, db.ForeignKey('Application.People.PersonID'), nullable=False)
    LastEditedWhen = db.Column(db.DateTime, nullable=False)
    
    def __repr__(self):
        return f'<InvoiceLine {self.InvoiceLineID}>' 
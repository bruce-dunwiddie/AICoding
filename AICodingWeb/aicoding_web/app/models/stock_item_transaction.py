from datetime import datetime
from app import db
from app.models.base import BaseModel

class StockItemTransaction(db.Model, BaseModel):
    """StockItemTransaction model"""
    
    __tablename__ = 'stock_item_transactions'
    
    StockItemTransactionID = db.Column(db.Integer, primary_key=True)
    StockItemID = db.Column(db.Integer, db.ForeignKey('stock_items.StockItemID'), nullable=False)
    TransactionTypeID = db.Column(db.Integer, db.ForeignKey('transaction_types.TransactionTypeID'), nullable=False)
    CustomerID = db.Column(db.Integer, db.ForeignKey('customers.CustomerID'))
    InvoiceID = db.Column(db.Integer, db.ForeignKey('invoices.InvoiceID'))
    SupplierID = db.Column(db.Integer, db.ForeignKey('suppliers.SupplierID'))
    PurchaseOrderID = db.Column(db.Integer, db.ForeignKey('purchase_orders.PurchaseOrderID'))
    TransactionOccurredWhen = db.Column(db.DateTime, nullable=False)
    Quantity = db.Column(db.Numeric(18, 3), nullable=False)
    LastEditedBy = db.Column(db.Integer, db.ForeignKey('people.PersonID'), nullable=False)
    LastEditedWhen = db.Column(db.DateTime, nullable=False)
    
    def __repr__(self):
        return f'<StockItemTransaction {self.StockItemTransactionID}>' 
from datetime import datetime
from app import db
from app.models.base import BaseModel

class SupplierTransaction(db.Model, BaseModel):
    """SupplierTransaction model"""
    
    __tablename__ = 'supplier_transactions'
    
    SupplierTransactionID = db.Column(db.Integer, primary_key=True)
    SupplierID = db.Column(db.Integer, db.ForeignKey('suppliers.SupplierID'), nullable=False)
    TransactionTypeID = db.Column(db.Integer, db.ForeignKey('transaction_types.TransactionTypeID'), nullable=False)
    PurchaseOrderID = db.Column(db.Integer, db.ForeignKey('purchase_orders.PurchaseOrderID'))
    PaymentMethodID = db.Column(db.Integer, db.ForeignKey('payment_methods.PaymentMethodID'))
    SupplierInvoiceNumber = db.Column(db.String(20))
    TransactionDate = db.Column(db.DateTime, nullable=False)
    AmountExcludingTax = db.Column(db.Numeric(18, 2), nullable=False)
    TaxAmount = db.Column(db.Numeric(18, 2), nullable=False)
    TransactionAmount = db.Column(db.Numeric(18, 2), nullable=False)
    OutstandingBalance = db.Column(db.Numeric(18, 2), nullable=False)
    FinalizationDate = db.Column(db.DateTime)
    LastEditedBy = db.Column(db.Integer, db.ForeignKey('people.PersonID'), nullable=False)
    LastEditedWhen = db.Column(db.DateTime, nullable=False)
    
    def __repr__(self):
        return f'<SupplierTransaction {self.SupplierTransactionID}>' 
from datetime import datetime
from app import db
from app.models.base import BaseModel

class CustomerTransaction(db.Model, BaseModel):
    """CustomerTransaction model"""
    
    __tablename__ = 'customer_transactions'
    
    CustomerTransactionID = db.Column(db.Integer, primary_key=True)
    CustomerID = db.Column(db.Integer, db.ForeignKey('customers.CustomerID'), nullable=False)
    TransactionTypeID = db.Column(db.Integer, db.ForeignKey('transaction_types.TransactionTypeID'), nullable=False)
    InvoiceID = db.Column(db.Integer, db.ForeignKey('invoices.InvoiceID'))
    PaymentMethodID = db.Column(db.Integer, db.ForeignKey('payment_methods.PaymentMethodID'))
    TransactionDate = db.Column(db.DateTime, nullable=False)
    AmountExcludingTax = db.Column(db.Numeric(18, 2), nullable=False)
    TaxAmount = db.Column(db.Numeric(18, 2), nullable=False)
    TransactionAmount = db.Column(db.Numeric(18, 2), nullable=False)
    OutstandingBalance = db.Column(db.Numeric(18, 2), nullable=False)
    FinalizationDate = db.Column(db.DateTime)
    IsFinalized = db.Column(db.Boolean, nullable=False)
    LastEditedBy = db.Column(db.Integer, db.ForeignKey('people.PersonID'), nullable=False)
    LastEditedWhen = db.Column(db.DateTime, nullable=False)
    
    def __repr__(self):
        return f'<CustomerTransaction {self.CustomerTransactionID}>' 
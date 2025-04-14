from datetime import datetime
from app import db
from app.models.base import BaseModel

class InvoiceLine(db.Model, BaseModel):
    """Invoice line model"""
    
    __tablename__ = 'invoice_lines'
    
    id = db.Column(db.Integer, primary_key=True)
    invoice_id = db.Column(db.Integer, db.ForeignKey('invoices.id'), nullable=False)
    stock_item_id = db.Column(db.Integer, db.ForeignKey('stock_items.id'), nullable=False)
    description = db.Column(db.String(100), nullable=False)
    package_type_id = db.Column(db.Integer, db.ForeignKey('package_types.id'), nullable=False)
    quantity = db.Column(db.Integer, nullable=False)
    unit_price = db.Column(db.Numeric(18, 2), nullable=False)
    tax_rate = db.Column(db.Numeric(18, 3), nullable=False)
    tax_amount = db.Column(db.Numeric(18, 2), nullable=False)
    line_profit = db.Column(db.Numeric(18, 2), nullable=False)
    extended_price = db.Column(db.Numeric(18, 2), nullable=False)
    last_edited_by = db.Column(db.Integer, db.ForeignKey('people.id'), nullable=False)
    last_edited_when = db.Column(db.DateTime, nullable=False)
    
    # Relationships
    invoice = db.relationship('Invoice', back_populates='invoice_lines')
    package_type = db.relationship('PackageType', backref='invoice_lines')
    last_edited_by_person = db.relationship('Person', foreign_keys=[last_edited_by], backref='edited_invoice_lines')
    
    def __repr__(self):
        return f'<InvoiceLine {self.id}>' 
from datetime import datetime
from app import db
from app.models.base import BaseModel

class SpecialDeal(db.Model, BaseModel):
    """SpecialDeal model"""
    
    __tablename__ = 'special_deals'
    
    SpecialDealID = db.Column(db.Integer, primary_key=True)
    StockItemID = db.Column(db.Integer, db.ForeignKey('stock_items.StockItemID'))
    CustomerID = db.Column(db.Integer, db.ForeignKey('customers.CustomerID'))
    BuyingGroupID = db.Column(db.Integer, db.ForeignKey('buying_groups.BuyingGroupID'))
    CustomerCategoryID = db.Column(db.Integer, db.ForeignKey('customer_categories.CustomerCategoryID'))
    StockGroupID = db.Column(db.Integer, db.ForeignKey('stock_groups.StockGroupID'))
    DealDescription = db.Column(db.String(30), nullable=False)
    StartDate = db.Column(db.Date, nullable=False)
    EndDate = db.Column(db.Date, nullable=False)
    DiscountAmount = db.Column(db.Numeric(18, 2))
    DiscountPercentage = db.Column(db.Numeric(18, 3))
    UnitPrice = db.Column(db.Numeric(18, 2))
    LastEditedBy = db.Column(db.Integer, db.ForeignKey('people.PersonID'), nullable=False)
    LastEditedWhen = db.Column(db.DateTime, nullable=False)
    
    def __repr__(self):
        return f'<SpecialDeal {self.SpecialDealID}>' 
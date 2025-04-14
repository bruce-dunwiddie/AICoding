from datetime import datetime
from app import db
from app.models.base import BaseModel

class StockItemHolding(db.Model, BaseModel):
    """StockItemHolding model"""
    
    __tablename__ = 'stock_item_holdings'
    
    StockItemID = db.Column(db.Integer, db.ForeignKey('stock_items.StockItemID'), primary_key=True)
    QuantityOnHand = db.Column(db.Integer, nullable=False)
    BinLocation = db.Column(db.String(20), nullable=False)
    LastStocktakeQuantity = db.Column(db.Integer, nullable=False)
    LastCostPrice = db.Column(db.Numeric(18, 2), nullable=False)
    ReorderLevel = db.Column(db.Integer, nullable=False)
    TargetStockLevel = db.Column(db.Integer, nullable=False)
    LastEditedBy = db.Column(db.Integer, db.ForeignKey('people.PersonID'), nullable=False)
    LastEditedWhen = db.Column(db.DateTime, nullable=False)
    
    def __repr__(self):
        return f'<StockItemHolding {self.StockItemID}>' 
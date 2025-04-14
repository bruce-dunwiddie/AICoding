from datetime import datetime
from app import db
from app.models.base import BaseModel

class StockItemStockGroup(db.Model, BaseModel):
    """StockItemStockGroup model"""
    
    __tablename__ = 'stock_item_stock_groups'
    
    StockItemStockGroupID = db.Column(db.Integer, primary_key=True)
    StockItemID = db.Column(db.Integer, db.ForeignKey('stock_items.StockItemID'), nullable=False)
    StockGroupID = db.Column(db.Integer, db.ForeignKey('stock_groups.StockGroupID'), nullable=False)
    LastEditedBy = db.Column(db.Integer, db.ForeignKey('people.PersonID'), nullable=False)
    LastEditedWhen = db.Column(db.DateTime, nullable=False)
    
    def __repr__(self):
        return f'<StockItemStockGroup {self.StockItemStockGroupID}>' 
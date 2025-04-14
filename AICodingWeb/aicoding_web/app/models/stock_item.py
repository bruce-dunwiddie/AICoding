from datetime import datetime
from app import db
from app.models.base import BaseModel

class StockItem(db.Model, BaseModel):
    """StockItem model"""
    
    __tablename__ = 'StockItems'
    __table_args__ = {'schema': 'Warehouse'}
    
    StockItemID = db.Column(db.Integer, primary_key=True)
    StockItemName = db.Column(db.String(100), nullable=False)
    SupplierID = db.Column(db.Integer, db.ForeignKey('Purchasing.Suppliers.SupplierID'), nullable=False)
    ColorID = db.Column(db.Integer, db.ForeignKey('Warehouse.Colors.ColorID'))
    UnitPackageID = db.Column(db.Integer, db.ForeignKey('Warehouse.PackageTypes.PackageTypeID'), nullable=False)
    OuterPackageID = db.Column(db.Integer, db.ForeignKey('Warehouse.PackageTypes.PackageTypeID'), nullable=False)
    Brand = db.Column(db.String(50))
    Size = db.Column(db.String(20))
    LeadTimeDays = db.Column(db.Integer, nullable=False)
    QuantityPerOuter = db.Column(db.Integer, nullable=False)
    IsChillerStock = db.Column(db.Boolean, nullable=False)
    Barcode = db.Column(db.String(50))
    TaxRate = db.Column(db.Numeric(18, 3), nullable=False)
    UnitPrice = db.Column(db.Numeric(18, 2), nullable=False)
    RecommendedRetailPrice = db.Column(db.Numeric(18, 2))
    TypicalWeightPerUnit = db.Column(db.Numeric(18, 3), nullable=False)
    MarketingComments = db.Column(db.Text)
    InternalComments = db.Column(db.Text)
    Photo = db.Column(db.LargeBinary)
    CustomFields = db.Column(db.JSON)
    Tags = db.Column(db.JSON)
    SearchDetails = db.Column(db.Text, nullable=False)
    LastEditedBy = db.Column(db.Integer, db.ForeignKey('Application.People.PersonID'), nullable=False)
    ValidFrom = db.Column(db.DateTime, nullable=False)
    ValidTo = db.Column(db.DateTime, nullable=False)
    
    def __repr__(self):
        return f'<StockItem {self.StockItemID}>' 
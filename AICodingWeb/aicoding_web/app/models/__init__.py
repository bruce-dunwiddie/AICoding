# Import all models to ensure they are registered with SQLAlchemy
from app.models.base import BaseModel
from app.models.user import User
from app.models.customer import Customer
from app.models.customer_category import CustomerCategory
from app.models.buying_group import BuyingGroup
from app.models.person import Person
from app.models.country import Country
from app.models.state_province import StateProvince
from app.models.city import City
from app.models.delivery_method import DeliveryMethod
from app.models.payment_method import PaymentMethod
from app.models.package_type import PackageType
from app.models.color import Color
from app.models.stock_item import StockItem
from app.models.stock_group import StockGroup
from app.models.stock_item_stock_group import StockItemStockGroup
from app.models.order import Order, OrderLine
from app.models.invoice import Invoice
from app.models.purchase_order import PurchaseOrder, PurchaseOrderLine
from app.models.supplier import Supplier
from app.models.transaction_type import TransactionType
from app.models.customer_transaction import CustomerTransaction
from app.models.special_deal import SpecialDeal
from app.models.stock_item_transaction import StockItemTransaction
from app.models.stock_item_holding import StockItemHolding 
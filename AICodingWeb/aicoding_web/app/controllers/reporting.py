from flask import Blueprint, render_template, request, jsonify
from flask_login import login_required
from sqlalchemy import func
from datetime import datetime, timedelta
from ..models.order import Order
from ..models.invoice import Invoice
from ..models.customer import Customer
from ..models.stock_item import StockItem
from app import db

reporting_bp = Blueprint('reporting', __name__)

@reporting_bp.route('/reports')
@login_required
def index():
    # Calculate quick stats
    stats = {}
    
    # Total orders in the last 30 days
    thirty_days_ago = datetime.now() - timedelta(days=30)
    stats['total_orders'] = Order.query.filter(Order.OrderDate >= thirty_days_ago).count()
    
    # Total revenue in the last 30 days
    revenue = db.session.query(func.sum(Invoice.TotalChillerItems + Invoice.TotalDryItems))\
        .filter(Invoice.InvoiceDate >= thirty_days_ago)\
        .scalar() or 0
    stats['total_revenue'] = f"${revenue:,.2f}"
    
    # Active customers (placed order in last 30 days)
    stats['active_customers'] = db.session.query(Order.CustomerID)\
        .filter(Order.OrderDate >= thirty_days_ago)\
        .distinct()\
        .count()
    
    # Low stock items (below reorder level)
    # For now, we'll just count all stock items since we don't have quantity tracking
    stats['low_stock_items'] = StockItem.query.count()
    
    return render_template('reporting/index.html', stats=stats)

@reporting_bp.route('/reports/sales')
@login_required
def sales():
    """Sales report"""
    start_date = request.args.get('start_date', (datetime.now() - timedelta(days=30)).strftime('%Y-%m-%d'))
    end_date = request.args.get('end_date', datetime.now().strftime('%Y-%m-%d'))
    
    # Sales by customer
    sales_by_customer = db.session.query(
        Customer.customer_name,
        func.count(Order.id).label('order_count'),
        func.sum(Order.total_amount).label('total_amount')
    ).join(Order).filter(
        Order.order_date.between(start_date, end_date)
    ).group_by(Customer.id, Customer.customer_name).all()
    
    # Sales by day
    sales_by_day = db.session.query(
        func.date(Order.order_date).label('date'),
        func.count(Order.id).label('order_count'),
        func.sum(Order.total_amount).label('total_amount')
    ).filter(
        Order.order_date.between(start_date, end_date)
    ).group_by(func.date(Order.order_date)).all()
    
    return render_template('reporting/sales.html',
                         sales_by_customer=sales_by_customer,
                         sales_by_day=sales_by_day,
                         start_date=start_date,
                         end_date=end_date)

@reporting_bp.route('/reports/inventory')
@login_required
def inventory():
    """Inventory report"""
    # Stock levels
    stock_levels = db.session.query(
        StockItem.stock_item_name,
        StockItem.unit_price,
        StockItemHolding.quantity_on_hand,
        StockItemHolding.reorder_level,
        StockItemHolding.target_stock_level
    ).join(StockItemHolding).all()
    
    # Low stock items
    low_stock = db.session.query(
        StockItem.stock_item_name,
        StockItemHolding.quantity_on_hand,
        StockItemHolding.reorder_level
    ).join(StockItemHolding).filter(
        StockItemHolding.quantity_on_hand <= StockItemHolding.reorder_level
    ).all()
    
    return render_template('reporting/inventory.html',
                         stock_levels=stock_levels,
                         low_stock=low_stock)

@reporting_bp.route('/reports/customers')
@login_required
def customers():
    """Customer report"""
    # Customer statistics
    customer_stats = db.session.query(
        Customer.customer_name,
        func.count(Order.id).label('order_count'),
        func.sum(Order.total_amount).label('total_amount'),
        func.avg(Order.total_amount).label('average_order_amount')
    ).join(Order).group_by(Customer.id, Customer.customer_name).all()
    
    # Customer categories
    category_stats = db.session.query(
        CustomerCategory.customer_category_name,
        func.count(Customer.id).label('customer_count')
    ).join(Customer).group_by(
        CustomerCategory.id,
        CustomerCategory.customer_category_name
    ).all()
    
    return render_template('reporting/customers.html',
                         customer_stats=customer_stats,
                         category_stats=category_stats) 
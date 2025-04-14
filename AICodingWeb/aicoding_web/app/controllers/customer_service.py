from flask import Blueprint, render_template, redirect, url_for, flash, request
from flask_login import login_required
from app import db
from app.models.customer import Customer
from app.models.order import Order
from app.forms.customer_service import CustomerForm

customer_service_bp = Blueprint('customer_service', __name__)

@customer_service_bp.route('/customers')
@login_required
def customers():
    """List all customers"""
    page = request.args.get('page', 1, type=int)
    customers = Customer.query.order_by(Customer.CustomerName).paginate(page=page, per_page=20)
    return render_template('customer_service/customers.html', customers=customers)

@customer_service_bp.route('/customers/<int:id>')
@login_required
def customer_detail(id):
    """Customer detail page"""
    customer = Customer.query.get_or_404(id)
    orders = Order.query.filter_by(CustomerID=id).order_by(Order.OrderDate.desc()).all()
    return render_template('customer_service/customer_detail.html', customer=customer, orders=orders)

@customer_service_bp.route('/customers/<int:id>/edit', methods=['GET', 'POST'])
@login_required
def customer_edit(id):
    """Edit customer"""
    customer = Customer.query.get_or_404(id)
    if request.method == 'POST':
        customer.CustomerName = request.form.get('CustomerName')
        customer.PhoneNumber = request.form.get('PhoneNumber')
        customer.FaxNumber = request.form.get('FaxNumber')
        customer.WebsiteURL = request.form.get('WebsiteURL')
        customer.DeliveryAddressLine1 = request.form.get('DeliveryAddressLine1')
        customer.DeliveryAddressLine2 = request.form.get('DeliveryAddressLine2')
        customer.DeliveryPostalCode = request.form.get('DeliveryPostalCode')
        customer.PostalAddressLine1 = request.form.get('PostalAddressLine1')
        customer.PostalAddressLine2 = request.form.get('PostalAddressLine2')
        customer.PostalPostalCode = request.form.get('PostalPostalCode')
        db.session.commit()
        flash('Customer updated successfully', 'success')
        return redirect(url_for('customer_service.customer_detail', id=id))
    return render_template('customer_service/customer_edit.html', customer=customer)

@customer_service_bp.route('/customers/<int:id>/orders')
@login_required
def customer_orders(id):
    """List customer orders"""
    customer = Customer.query.get_or_404(id)
    page = request.args.get('page', 1, type=int)
    orders = Order.query.filter_by(customer_id=id).order_by(Order.OrderDate.desc()).paginate(page=page, per_page=20)
    return render_template('customer_service/customer_orders.html', customer=customer, orders=orders)

@customer_service_bp.route('/customers/<int:id>/orders/<int:order_id>')
@login_required
def customer_order_detail(id, order_id):
    """Customer order detail page"""
    customer = Customer.query.get_or_404(id)
    order = Order.query.get_or_404(order_id)
    if order.customer_id != id:
        flash('Order not found', 'error')
        return redirect(url_for('customer_service.customer_orders', id=id))
    return render_template('customer_service/customer_order_detail.html', customer=customer, order=order) 
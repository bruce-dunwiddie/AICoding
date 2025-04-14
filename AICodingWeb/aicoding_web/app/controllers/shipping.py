from flask import Blueprint, render_template, redirect, url_for, flash, request
from flask_login import login_required
from app import db
from app.models.order import Order
from app.models.invoice import Invoice
from app.forms.shipping import OrderForm
from datetime import datetime

shipping_bp = Blueprint('shipping', __name__)

@shipping_bp.route('/orders')
@login_required
def orders():
    """List all orders"""
    page = request.args.get('page', 1, type=int)
    orders = Order.query.order_by(Order.OrderDate.desc()).paginate(page=page, per_page=20)
    return render_template('shipping/orders.html', orders=orders)

@shipping_bp.route('/orders/<int:id>')
@login_required
def order_detail(id):
    """Order detail page"""
    order = Order.query.get_or_404(id)
    return render_template('shipping/order_detail.html', order=order)

@shipping_bp.route('/orders/<int:id>/edit', methods=['GET', 'POST'])
@login_required
def order_edit(id):
    """Edit order"""
    order = Order.query.get_or_404(id)
    if request.method == 'POST':
        order.CustomerPurchaseOrderNumber = request.form.get('CustomerPurchaseOrderNumber')
        order.ExpectedDeliveryDate = datetime.strptime(request.form.get('ExpectedDeliveryDate'), '%Y-%m-%d').date()
        order.Comments = request.form.get('Comments')
        order.DeliveryInstructions = request.form.get('DeliveryInstructions')
        order.InternalComments = request.form.get('InternalComments')
        db.session.commit()
        flash('Order updated successfully', 'success')
        return redirect(url_for('shipping.order_detail', id=id))
    return render_template('shipping/order_edit.html', order=order)

@shipping_bp.route('/orders/<int:id>/ship', methods=['POST'])
@login_required
def ship_order(id):
    """Ship an order"""
    order = Order.query.get_or_404(id)
    if order.PickingCompletedWhen:
        flash('Order has already been shipped', 'error')
        return redirect(url_for('shipping.order_detail', id=id))
    
    # Create invoice
    invoice = Invoice(
        CustomerID=order.CustomerID,
        BillToCustomerID=order.CustomerID,
        OrderID=order.OrderID,
        DeliveryMethodID=1,  # Default delivery method
        ContactPersonID=order.ContactPersonID,
        AccountsPersonID=order.ContactPersonID,
        SalespersonPersonID=order.SalespersonPersonID,
        PackedByPersonID=order.PickedByPersonID,
        InvoiceDate=datetime.now().date(),
        CustomerPurchaseOrderNumber=order.CustomerPurchaseOrderNumber,
        IsCreditNote=False,
        CreditNoteReason=None,
        Comments=order.Comments,
        DeliveryInstructions=order.DeliveryInstructions,
        InternalComments=order.InternalComments,
        TotalDryItems=0,
        TotalChillerItems=0,
        DeliveryRun=None,
        RunPosition=None,
        ReturnedDeliveryData=None,
        ConfirmedDeliveryTime=None,
        ConfirmedReceivedBy=None,
        LastEditedBy=current_user.PersonID,
        LastEditedWhen=datetime.now()
    )
    db.session.add(invoice)
    
    # Mark order as shipped
    order.PickingCompletedWhen = datetime.now()
    db.session.commit()
    
    flash('Order has been shipped successfully', 'success')
    return redirect(url_for('shipping.order_detail', id=id)) 
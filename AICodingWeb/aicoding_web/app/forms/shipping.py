from flask_wtf import FlaskForm
from wtforms import StringField, TextAreaField, DateField, SelectField, SubmitField
from wtforms.validators import DataRequired, Optional
from app import db
from app.models.customer import Customer
from app.models.delivery_method import DeliveryMethod
from app.models.person import Person

class OrderForm(FlaskForm):
    """Order form"""
    customer_id = SelectField('Customer', coerce=int, validators=[DataRequired()])
    delivery_method_id = SelectField('Delivery Method', coerce=int, validators=[DataRequired()])
    contact_person_id = SelectField('Contact Person', coerce=int, validators=[DataRequired()])
    accounts_person_id = SelectField('Accounts Person', coerce=int, validators=[DataRequired()])
    salesperson_person_id = SelectField('Sales Person', coerce=int, validators=[DataRequired()])
    packed_by_person_id = SelectField('Packed By', coerce=int, validators=[DataRequired()])
    expected_delivery_date = DateField('Expected Delivery Date', validators=[DataRequired()])
    customer_purchase_order_number = StringField('Customer PO Number', validators=[Optional()])
    comments = TextAreaField('Comments', validators=[Optional()])
    delivery_instructions = TextAreaField('Delivery Instructions', validators=[Optional()])
    internal_comments = TextAreaField('Internal Comments', validators=[Optional()])
    submit = SubmitField('Save')
    
    def __init__(self, *args, **kwargs):
        super(OrderForm, self).__init__(*args, **kwargs)
        self.customer_id.choices = [(c.id, c.customer_name) for c in Customer.query.order_by(Customer.customer_name).all()]
        self.delivery_method_id.choices = [(d.id, d.delivery_method_name) for d in DeliveryMethod.query.order_by(DeliveryMethod.delivery_method_name).all()]
        self.contact_person_id.choices = [(p.id, p.full_name) for p in Person.query.order_by(Person.full_name).all()]
        self.accounts_person_id.choices = [(p.id, p.full_name) for p in Person.query.order_by(Person.full_name).all()]
        self.salesperson_person_id.choices = [(p.id, p.full_name) for p in Person.query.order_by(Person.full_name).all()]
        self.packed_by_person_id.choices = [(p.id, p.full_name) for p in Person.query.order_by(Person.full_name).all()] 
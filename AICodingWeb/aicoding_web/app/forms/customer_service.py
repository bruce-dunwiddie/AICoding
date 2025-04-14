from flask_wtf import FlaskForm
from wtforms import StringField, TextAreaField, SelectField, SubmitField
from wtforms.validators import DataRequired, Optional, Length
from app import db
from app.models.customer_category import CustomerCategory
from app.models.buying_group import BuyingGroup
from app.models.person import Person
from app.models.delivery_method import DeliveryMethod
from app.models.city import City

class CustomerForm(FlaskForm):
    """Customer form"""
    customer_name = StringField('Customer Name', validators=[DataRequired(), Length(max=100)])
    customer_category_id = SelectField('Customer Category', coerce=int, validators=[DataRequired()])
    buying_group_id = SelectField('Buying Group', coerce=int, validators=[Optional()])
    primary_contact_person_id = SelectField('Primary Contact', coerce=int, validators=[DataRequired()])
    alternate_contact_person_id = SelectField('Alternate Contact', coerce=int, validators=[Optional()])
    delivery_method_id = SelectField('Delivery Method', coerce=int, validators=[Optional()])
    delivery_city_id = SelectField('Delivery City', coerce=int, validators=[DataRequired()])
    postal_city_id = SelectField('Postal City', coerce=int, validators=[DataRequired()])
    credit_limit = StringField('Credit Limit', validators=[Optional()])
    payment_days = StringField('Payment Days', validators=[Optional()])
    phone_number = StringField('Phone Number', validators=[Optional(), Length(max=20)])
    fax_number = StringField('Fax Number', validators=[Optional(), Length(max=20)])
    website_url = StringField('Website URL', validators=[Optional(), Length(max=256)])
    delivery_address_line1 = StringField('Delivery Address Line 1', validators=[DataRequired(), Length(max=60)])
    delivery_address_line2 = StringField('Delivery Address Line 2', validators=[Optional(), Length(max=60)])
    delivery_postal_code = StringField('Delivery Postal Code', validators=[DataRequired(), Length(max=10)])
    postal_address_line1 = StringField('Postal Address Line 1', validators=[DataRequired(), Length(max=60)])
    postal_address_line2 = StringField('Postal Address Line 2', validators=[Optional(), Length(max=60)])
    postal_postal_code = StringField('Postal Postal Code', validators=[DataRequired(), Length(max=10)])
    submit = SubmitField('Save')
    
    def __init__(self, *args, **kwargs):
        super(CustomerForm, self).__init__(*args, **kwargs)
        self.customer_category_id.choices = [(c.id, c.customer_category_name) for c in CustomerCategory.query.order_by(CustomerCategory.customer_category_name).all()]
        self.buying_group_id.choices = [(b.id, b.buying_group_name) for b in BuyingGroup.query.order_by(BuyingGroup.buying_group_name).all()]
        self.primary_contact_person_id.choices = [(p.id, p.full_name) for p in Person.query.order_by(Person.full_name).all()]
        self.alternate_contact_person_id.choices = [(p.id, p.full_name) for p in Person.query.order_by(Person.full_name).all()]
        self.delivery_method_id.choices = [(d.id, d.delivery_method_name) for d in DeliveryMethod.query.order_by(DeliveryMethod.delivery_method_name).all()]
        self.delivery_city_id.choices = [(c.id, c.city_name) for c in City.query.order_by(City.city_name).all()]
        self.postal_city_id.choices = [(c.id, c.city_name) for c in City.query.order_by(City.city_name).all()] 
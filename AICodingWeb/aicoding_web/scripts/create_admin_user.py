#!/usr/bin/env python
"""
Script to create an admin user with proper Flask password hashing.
This ensures the password hash is compatible with Flask-Login's verification.
"""
import os
import sys
import uuid
from werkzeug.security import generate_password_hash

# Add the parent directory to the path so we can import the app
sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from app import create_app, db
from app.models.user import User, Role, user_roles

def create_admin_user():
    """Create an admin user with proper Flask password hashing."""
    app = create_app()
    
    with app.app_context():
        # Check if admin user already exists
        admin_email = 'admin2@example.com'
        existing_user = User.query.filter_by(Email=admin_email).first()
        
        if existing_user:
            print(f"Admin user with Email {admin_email} already exists.")
            return
        
        # Generate a proper UUID for the user ID
        user_id = str(uuid.uuid4())
        
        # Create the admin user with Flask's password hashing
        admin_user = User(
            Id=user_id,
            Email=admin_email,
            UserName=admin_email,
            NormalizedEmail=admin_email.upper(),
            NormalizedUserName=admin_email.upper(),
            EmailConfirmed=True,
            SecurityStamp=str(uuid.uuid4()),
            ConcurrencyStamp=str(uuid.uuid4()),
            PhoneNumberConfirmed=False,
            TwoFactorEnabled=False,
            LockoutEnabled=True,
            AccessFailedCount=0
        )
        admin_user.set_password('Admin123!')  # This will be hashed by the User model
        
        # Get or create the Admin role
        admin_role = Role.query.filter_by(Name='Admin').first()
        if not admin_role:
            admin_role = Role(
                Id=str(uuid.uuid4()),
                Name='Admin',
                NormalizedName='ADMIN',
                ConcurrencyStamp=str(uuid.uuid4())
            )
            db.session.add(admin_role)
            db.session.flush()  # Flush to get the role ID
        
        # Add the user to the database
        db.session.add(admin_user)
        db.session.flush()  # Flush to get the user ID
        
        # Create the user-role association using the association table
        stmt = user_roles.insert().values(
            UserId=admin_user.Id,
            RoleId=admin_role.Id
        )
        db.session.execute(stmt)
        
        # Commit the transaction
        db.session.commit()
        
        print(f"Admin user created successfully with Email: {admin_email}")
        print(f"User ID: {user_id}")
        print(f"Role ID: {admin_role.Id}")
        print("Password: Admin123!")

if __name__ == "__main__":
    create_admin_user() 
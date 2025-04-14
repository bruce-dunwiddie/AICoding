# AICoding Web

A modern web application for managing orders, customers, and inventory. Built with Flask and SQLAlchemy.

## Features

- User authentication and authorization
- Order management and shipping
- Customer relationship management
- Inventory tracking
- Business analytics and reporting
- Responsive design with Bootstrap 5

## Prerequisites

- Python 3.8 or higher
- PostgreSQL 12 or higher
- pip (Python package installer)

## Installation

1. Clone the repository:
```bash
git clone https://github.com/yourusername/aicoding_web.git
cd aicoding_web
```

2. Create a virtual environment:
```bash
python -m venv venv
source venv/bin/activate  # On Windows: venv\Scripts\activate
```

3. Install dependencies:
```bash
pip install -r requirements.txt
```

4. Set up environment variables:
Create a `.env` file in the root directory with the following variables:
```
FLASK_APP=run.py
FLASK_ENV=development
SECRET_KEY=your-secret-key
DATABASE_URL=postgresql://username:password@localhost/dbname
```

5. Initialize the database:
```bash
flask db upgrade
```

6. Run the development server:
```bash
flask run
```

The application will be available at `http://localhost:5000`.

## Project Structure

```
aicoding_web/
├── app/
│   ├── controllers/    # Route handlers
│   ├── models/        # Database models
│   ├── services/      # Business logic
│   ├── forms/         # Form classes
│   ├── templates/     # Jinja2 templates
│   ├── static/        # Static files (CSS, JS)
│   └── __init__.py    # Application factory
├── migrations/        # Database migrations
├── tests/            # Test suite
├── venv/             # Virtual environment
├── .env              # Environment variables
├── .gitignore        # Git ignore rules
├── requirements.txt   # Python dependencies
└── run.py            # Application entry point
```

## Development

To run the application in development mode:

```bash
export FLASK_ENV=development  # On Windows: set FLASK_ENV=development
flask run
```

To create a new database migration:

```bash
flask db migrate -m "Description of changes"
flask db upgrade
```

## Testing

To run the test suite:

```bash
python -m pytest
```

## Deployment

For production deployment:

1. Set up environment variables:
```
FLASK_ENV=production
SECRET_KEY=your-secure-secret-key
DATABASE_URL=your-production-database-url
```

2. Configure your web server (e.g., Nginx, Apache) to proxy requests to the Flask application.

3. Use a process manager (e.g., Gunicorn, uWSGI) to run the application:
```bash
gunicorn -w 4 -b 127.0.0.1:8000 run:app
```

## Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## License

This project is licensed under the MIT License - see the LICENSE file for details. 
from sqlalchemy.types import TypeDecorator, String
import json

class Geography(TypeDecorator):
    """Custom type for handling SQL Server geography columns"""
    impl = String
    cache_ok = True

    def process_result_value(self, value, dialect):
        """Convert the geography value to a string representation"""
        if value is None:
            return None
        # Convert geography to WKT (Well-Known Text) format
        return str(value)

    def process_bind_param(self, value, dialect):
        """Convert the string value back to geography when saving"""
        if value is None:
            return None
        return value 
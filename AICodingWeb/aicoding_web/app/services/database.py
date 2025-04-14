import os
from azure.identity import DefaultAzureCredential
from azure.keyvault.secrets import SecretClient
from dotenv import load_dotenv

# Load environment variables
load_dotenv()

class DatabaseConnectionService:
    """Service for retrieving database connection strings"""
    
    def __init__(self):
        self._secret_client = None
    
    def _is_key_vault_configured(self):
        """Check if Azure Key Vault is configured"""
        key_vault_uri = os.environ.get('KEY_VAULT_URI')
        return key_vault_uri is not None and key_vault_uri.strip() != ''
    
    def _get_secret_client(self):
        """Get or create the Azure Key Vault secret client"""
        if self._secret_client is None:
            key_vault_uri = os.environ.get('KEY_VAULT_URI')
            if not key_vault_uri:
                raise ValueError("Key Vault URI is not configured.")
            self._secret_client = SecretClient(
                vault_url=key_vault_uri,
                credential=DefaultAzureCredential()
            )
        return self._secret_client
    
    async def get_connection_string(self):
        """Get the database connection string from Key Vault or environment"""
        if self._is_key_vault_configured():
            try:
                secret_client = self._get_secret_client()
                secret = await secret_client.get_secret("Database-ConnectionString")
                return secret.value
            except Exception as e:
                # Log the error but continue to fallback
                print(f"Failed to get connection string from Key Vault: {str(e)}")
        
        # Fallback to environment variable
        connection_string = os.environ.get('DATABASE_URL')
        if not connection_string:
            raise ValueError("Connection string 'DATABASE_URL' not found in environment and Key Vault is not configured or accessible.")
        
        return connection_string 
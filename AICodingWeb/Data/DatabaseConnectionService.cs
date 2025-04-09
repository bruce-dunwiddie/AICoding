using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace AICodingWeb.Data
{
    public interface IDatabaseConnectionService
    {
        Task<string> GetConnectionStringAsync();
    }

    public class DatabaseConnectionService : IDatabaseConnectionService
    {
        private readonly IConfiguration _configuration;
        private SecretClient? _secretClient;

        public DatabaseConnectionService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private bool IsKeyVaultConfigured()
        {
            var keyVaultUri = _configuration.GetValue<string>("KeyVault:Uri");
            return !string.IsNullOrEmpty(keyVaultUri);
        }

        private SecretClient GetSecretClient()
        {
            if (_secretClient == null)
            {
                var keyVaultUri = _configuration.GetValue<string>("KeyVault:Uri");
                if (string.IsNullOrEmpty(keyVaultUri))
                {
                    throw new InvalidOperationException("Key Vault URI is not configured.");
                }
                _secretClient = new SecretClient(new Uri(keyVaultUri), new DefaultAzureCredential());
            }
            return _secretClient;
        }

        public async Task<string> GetConnectionStringAsync()
        {
            if (IsKeyVaultConfigured())
            {
                try
                {
                    var secretClient = GetSecretClient();
                    return (await secretClient.GetSecretAsync("Database-ConnectionString")).Value.Value;
                }
                catch (Exception ex)
                {
                    // Log the error but continue to fallback
                    Console.WriteLine($"Failed to get connection string from Key Vault: {ex.Message}");
                }
            }

            // Fallback to configuration
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found in configuration and Key Vault is not configured or accessible.");
            }
            
            return connectionString;
        }
    }
} 
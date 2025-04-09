using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AICodingWeb.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var logger = serviceProvider.GetRequiredService<ILogger<WideWorldImportersContext>>();
            logger.LogInformation("Starting database initialization...");

            try
            {
                // Create roles
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                string[] roleNames = { "Admin", "CustomerService", "Shipping", "Reporting" };
                
                foreach (var roleName in roleNames)
                {
                    if (!await roleManager.RoleExistsAsync(roleName))
                    {
                        await roleManager.CreateAsync(new IdentityRole(roleName));
                        logger.LogInformation($"Created role: {roleName}");
                    }
                }

                // Create admin user
                var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var adminEmail = "admin@example.com";
                var adminUser = await userManager.FindByEmailAsync(adminEmail);
                
                if (adminUser == null)
                {
                    adminUser = new IdentityUser
                    {
                        UserName = adminEmail,
                        Email = adminEmail,
                        EmailConfirmed = true
                    };
                    
                    var result = await userManager.CreateAsync(adminUser, "Admin123!");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                        logger.LogInformation("Created admin user");
                    }
                    else
                    {
                        logger.LogError($"Failed to create admin user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                    }
                }

                // Create test users for each role
                foreach (var roleName in roleNames.Where(r => r != "Admin"))
                {
                    var email = $"{roleName.ToLower()}@example.com";
                    var user = await userManager.FindByEmailAsync(email);
                    
                    if (user == null)
                    {
                        user = new IdentityUser
                        {
                            UserName = email,
                            Email = email,
                            EmailConfirmed = true
                        };
                        
                        var result = await userManager.CreateAsync(user, $"{roleName}123!");
                        if (result.Succeeded)
                        {
                            await userManager.AddToRoleAsync(user, roleName);
                            logger.LogInformation($"Created {roleName} user");
                        }
                        else
                        {
                            logger.LogError($"Failed to create {roleName} user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                        }
                    }
                }

                logger.LogInformation("Database initialization completed successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while initializing the database.");
                throw;
            }
        }
    }
} 
-- Create Application schema if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'Application')
BEGIN
    EXEC('CREATE SCHEMA [Application]')
END
GO

-- Insert roles
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp])
VALUES 
    (NEWID(), 'CustomerService', 'CUSTOMERSERVICE', NEWID()),
    (NEWID(), 'Shipping', 'SHIPPING', NEWID()),
    (NEWID(), 'Reporting', 'REPORTING', NEWID()),
    (NEWID(), 'Admin', 'ADMIN', NEWID());

-- Create default admin user (password: Admin123!)
-- Note: In production, you should change this password immediately
DECLARE @AdminUserId NVARCHAR(450) = NEWID();
DECLARE @AdminRoleId NVARCHAR(450);

SELECT @AdminRoleId = Id FROM [dbo].[AspNetRoles] WHERE [Name] = 'Admin';

INSERT INTO [dbo].[AspNetUsers] (
    [Id],
    [UserName],
    [NormalizedUserName],
    [Email],
    [NormalizedEmail],
    [EmailConfirmed],
    [PasswordHash],
    [SecurityStamp],
    [ConcurrencyStamp],
    [PhoneNumberConfirmed],
    [TwoFactorEnabled],
    [LockoutEnabled],
    [AccessFailedCount]
)
VALUES (
    @AdminUserId,
    'admin@worldwideimporters.com',
    'ADMIN@WORLDWIDEIMPORTERS.COM',
    'admin@worldwideimporters.com',
    'ADMIN@WORLDWIDEIMPORTERS.COM',
    1, -- EmailConfirmed
    'AQAAAAIAAYagAAAAELbGqWlVvZVBCX6T7UY7qOdXHFwbHDGUYHxDC0UL7RsLzGj+RgQKF3H4lY8K7Xbw5w==', -- Password: Admin123!
    NEWID(), -- SecurityStamp
    NEWID(), -- ConcurrencyStamp
    0, -- PhoneNumberConfirmed
    0, -- TwoFactorEnabled
    1, -- LockoutEnabled
    0  -- AccessFailedCount
);

-- Assign admin role to admin user
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId])
VALUES (@AdminUserId, @AdminRoleId); 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AICodingWeb.Models;

namespace AICodingWeb.Data.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("People", "Application");

            builder.HasIndex(e => e.FullName)
                .HasDatabaseName("IX_Application_People_FullName");

            builder.HasIndex(e => e.EmailAddress)
                .HasDatabaseName("IX_Application_People_EmailAddress");

            builder.HasIndex(e => e.IsEmployee)
                .HasDatabaseName("IX_Application_People_IsEmployee");

            builder.HasIndex(e => e.IsSalesperson)
                .HasDatabaseName("IX_Application_People_IsSalesperson");

            builder.HasIndex(e => e.IsSystemUser)
                .HasDatabaseName("IX_Application_People_IsSystemUser");

            builder.HasIndex(e => e.LogonName)
                .HasDatabaseName("UQ_Application_People_LogonName")
                .IsUnique();

            builder.Property(e => e.PersonID).ValueGeneratedNever();
            builder.Property(e => e.FullName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.PreferredName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.SearchName).HasMaxLength(101).IsRequired();
            builder.Property(e => e.IsPermittedToLogon).IsRequired();
            builder.Property(e => e.LogonName).HasMaxLength(50);
            builder.Property(e => e.IsExternalLogonProvider).IsRequired();
            builder.Property(e => e.HashedPassword).HasColumnType("varbinary(max)");
            builder.Property(e => e.IsSystemUser).IsRequired();
            builder.Property(e => e.IsEmployee).IsRequired();
            builder.Property(e => e.IsSalesperson).IsRequired();
            builder.Property(e => e.UserPreferences).HasColumnType("nvarchar(max)");
            builder.Property(e => e.PhoneNumber).HasMaxLength(20);
            builder.Property(e => e.FaxNumber).HasMaxLength(20);
            builder.Property(e => e.EmailAddress).HasMaxLength(256);
            builder.Property(e => e.Photo).HasColumnType("varbinary(max)");
            builder.Property(e => e.CustomFields).HasColumnType("nvarchar(max)");
            builder.Property(e => e.OtherLanguages).HasColumnType("nvarchar(max)");
            builder.Property(e => e.LastEditedBy).IsRequired();
        }
    }
} 
using System;
using System.Collections.Generic;

namespace AICodingWeb.Models
{
    public class Person
    {
        public int PersonID { get; set; }
        public string FullName { get; set; }
        public string PreferredName { get; set; }
        public string SearchName { get; set; }
        public bool IsPermittedToLogon { get; set; }
        public string LogonName { get; set; }
        public bool IsExternalLogonProvider { get; set; }
        public byte[] HashedPassword { get; set; }
        public bool IsSystemUser { get; set; }
        public bool IsEmployee { get; set; }
        public bool IsSalesperson { get; set; }
        public string UserPreferences { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string EmailAddress { get; set; }
        public byte[] Photo { get; set; }
        public string CustomFields { get; set; }
        public string OtherLanguages { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public virtual ICollection<Customer> PrimaryContactCustomers { get; set; }
        public virtual ICollection<Customer> AlternateContactCustomers { get; set; }
        public virtual ICollection<Supplier> PrimaryContactSuppliers { get; set; }
        public virtual ICollection<Supplier> AlternateContactSuppliers { get; set; }
        public virtual ICollection<Order> PickedByOrders { get; set; }
        public virtual ICollection<Order> SalespersonOrders { get; set; }
        public virtual ICollection<Invoice> ContactPersonInvoices { get; set; }
        public virtual ICollection<Invoice> AccountsPersonInvoices { get; set; }
        public virtual ICollection<Invoice> SalespersonInvoices { get; set; }
        public virtual ICollection<Invoice> PackedByPersonInvoices { get; set; }
        public virtual ICollection<PurchaseOrder> ContactPersonPurchaseOrders { get; set; }
    }
} 
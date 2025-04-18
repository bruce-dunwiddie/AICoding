using System;
using System.Collections.Generic;

namespace AICodingWeb.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int BillToCustomerID { get; set; }
        public int CustomerCategoryID { get; set; }
        public int? BuyingGroupID { get; set; }
        public int PrimaryContactPersonID { get; set; }
        public int? AlternateContactPersonID { get; set; }
        public int DeliveryMethodID { get; set; }
        public int DeliveryCityID { get; set; }
        public int PostalCityID { get; set; }
        public decimal? CreditLimit { get; set; }
        public DateTime AccountOpenedDate { get; set; }
        public decimal StandardDiscountPercentage { get; set; }
        public bool IsStatementSent { get; set; }
        public bool IsOnCreditHold { get; set; }
        public int PaymentDays { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string DeliveryRun { get; set; }
        public string RunPosition { get; set; }
        public string WebsiteURL { get; set; }
        public string DeliveryAddressLine1 { get; set; }
        public string DeliveryAddressLine2 { get; set; }
        public string DeliveryPostalCode { get; set; }
        public string DeliveryLocation { get; set; }
        public string PostalAddressLine1 { get; set; }
        public string PostalAddressLine2 { get; set; }
        public string PostalPostalCode { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public virtual Customer BillToCustomer { get; set; }
        public virtual CustomerCategory CustomerCategory { get; set; }
        public virtual BuyingGroup BuyingGroup { get; set; }
        public virtual Person PrimaryContactPerson { get; set; }
        public virtual Person AlternateContactPerson { get; set; }
        public virtual DeliveryMethod DeliveryMethod { get; set; }
        public virtual City DeliveryCity { get; set; }
        public virtual City PostalCity { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Invoice> BillToCustomerInvoices { get; set; }
        public virtual ICollection<Invoice> CustomerInvoices { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<CustomerTransaction> CustomerTransactions { get; set; }
        public virtual ICollection<StockItemTransaction> StockItemTransactions { get; set; }
        public virtual ICollection<SpecialDeal> SpecialDeals { get; set; }
    }
} 
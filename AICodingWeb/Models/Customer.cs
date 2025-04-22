using System;
using System.Collections.Generic;

namespace AICodingWeb.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string? CustomerName { get; set; }
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
        public string? PhoneNumber { get; set; }
        public string? FaxNumber { get; set; }
        public string? DeliveryRun { get; set; }
        public string? RunPosition { get; set; }
        public string? WebsiteURL { get; set; }
        public string? DeliveryAddressLine1 { get; set; }
        public string? DeliveryAddressLine2 { get; set; }
        public string? DeliveryPostalCode { get; set; }
        public string? PostalAddressLine1 { get; set; }
        public string? PostalAddressLine2 { get; set; }
        public string? PostalPostalCode { get; set; }
        public int LastEditedBy { get; set; }
    }
} 
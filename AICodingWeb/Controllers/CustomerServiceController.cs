using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using AICodingWeb.Data;
using AICodingWeb.Models;

namespace AICodingWeb.Controllers
{
    [Authorize(Policy = "CustomerService")]
    public class CustomerServiceController : Controller
    {
        private readonly WideWorldImportersContext _context;
        private const int PageSize = 20;

        public CustomerServiceController(WideWorldImportersContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SearchOrders(string customerName, DateTime? orderDate, string orderStatus, int page = 1)
        {
            // Store search parameters in ViewBag for form persistence
            ViewBag.CustomerName = customerName;
            ViewBag.OrderDate = orderDate?.ToString("yyyy-MM-dd");
            ViewBag.OrderStatus = orderStatus;

            // Start with base query
            var query = _context.Orders.AsQueryable();

            // Apply filters
            if (!string.IsNullOrWhiteSpace(customerName))
            {
                query = query.Where(o => o.Customer.CustomerName.Contains(customerName));
            }

            if (orderDate.HasValue)
            {
                query = query.Where(o => o.OrderDate.Date == orderDate.Value.Date);
            }

            if (!string.IsNullOrWhiteSpace(orderStatus))
            {
                if (orderStatus == "unshipped")
                {
                    query = query.Where(o => o.PickingCompletedWhen == null);
                }
                else if (orderStatus == "shipped")
                {
                    query = query.Where(o => o.PickingCompletedWhen != null);
                }
            }

            // Order by date descending (newest first)
            query = query.OrderByDescending(o => o.OrderDate);

            // Get total count for pagination
            var totalOrders = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalOrders / (double)PageSize);

            // Ensure page is within valid range
            page = Math.Max(1, Math.Min(page, totalPages));

            // Use a projection to select only the properties we need with pagination
            var orderViewModels = await query
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .Select(o => new OrderSearchViewModel
                {
                    OrderID = o.OrderID,
                    CustomerName = o.Customer.CustomerName,
                    OrderDate = o.OrderDate,
                    ExpectedDeliveryDate = o.ExpectedDeliveryDate,
                    PickingCompletedWhen = o.PickingCompletedWhen
                })
                .ToListAsync();

            // Pass pagination info to the view
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.TotalOrders = totalOrders;

            return View(orderViewModels);
        }

        public IActionResult EditOrder(int id)
        {
            return View();
        }
    }

    public class OrderSearchViewModel
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public DateTime? PickingCompletedWhen { get; set; }
    }
} 
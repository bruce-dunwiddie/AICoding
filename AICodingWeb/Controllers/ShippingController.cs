using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using AICodingWeb.Data;
using AICodingWeb.Models;

namespace AICodingWeb.Controllers
{
    [Authorize(Policy = "Shipping")]
    public class ShippingController : Controller
    {
        private readonly WideWorldImportersContext _context;
        private const int PageSize = 50;

        public ShippingController(WideWorldImportersContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            // Get the base query for unshipped orders
            var unshippedOrdersQuery = _context.Orders
                .Where(o => o.OrderDate <= DateTime.Now && o.PickingCompletedWhen == null)
                .OrderBy(o => o.OrderDate);

            // Get total count for pagination
            var totalOrders = await unshippedOrdersQuery.CountAsync();
            var totalPages = (int)Math.Ceiling(totalOrders / (double)PageSize);

            // Ensure page is within valid range
            page = Math.Max(1, Math.Min(page, totalPages));

            // Get the current page of orders with a projection
            var orders = await unshippedOrdersQuery
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .Select(o => new OrderViewModel
                {
                    OrderID = o.OrderID,
                    CustomerName = o.Customer.CustomerName,
                    OrderDate = o.OrderDate,
                    ExpectedDeliveryDate = o.ExpectedDeliveryDate,
                    CustomerPurchaseOrderNumber = o.CustomerPurchaseOrderNumber
                })
                .ToListAsync();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.TotalOrders = totalOrders;

            return View(orders);
        }

        [HttpPost]
        public async Task<IActionResult> MarkAsShipped(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                order.PickingCompletedWhen = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }

    // View model for displaying order information
    public class OrderViewModel
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public string CustomerPurchaseOrderNumber { get; set; }
    }
} 
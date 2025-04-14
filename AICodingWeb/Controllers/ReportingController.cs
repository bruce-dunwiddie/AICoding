using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using AICodingWeb.Data;
using AICodingWeb.Models;

namespace AICodingWeb.Controllers
{
    [Authorize(Policy = "Reporting")]
    public class ReportingController : Controller
    {
        private readonly WideWorldImportersContext _context;

        public ReportingController(WideWorldImportersContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SalesReport()
        {
            return View();
        }

        public async Task<IActionResult> InventoryReport(string category, string stockLevel, string sortBy)
        {
            // Store filter parameters in ViewBag for form persistence
            ViewBag.Category = category;
            ViewBag.StockLevel = stockLevel;
            ViewBag.SortBy = sortBy;

            // Get all stock items with their stock groups
            var query = _context.StockItems
                .Include(si => si.StockItemStockGroups)
                    .ThenInclude(sisg => sisg.StockGroup)
                .AsQueryable();

            // Apply category filter if specified
            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query.Where(si => si.StockItemStockGroups.Any(sisg => 
                    sisg.StockGroup.StockGroupName.Contains(category)));
            }

            // Get stock levels for each item
            var stockLevels = await _context.StockItemTransactions
                .GroupBy(sit => sit.StockItemID)
                .Select(g => new
                {
                    StockItemID = g.Key,
                    CurrentStock = g.Sum(sit => sit.Quantity)
                })
                .ToDictionaryAsync(sl => sl.StockItemID, sl => sl.CurrentStock);

            // Apply stock level filter
            if (!string.IsNullOrWhiteSpace(stockLevel))
            {
                if (stockLevel == "low")
                {
                    query = query.Where(si => stockLevels.ContainsKey(si.StockItemID) && 
                        stockLevels[si.StockItemID] > 0 && stockLevels[si.StockItemID] < 10);
                }
                else if (stockLevel == "out")
                {
                    query = query.Where(si => !stockLevels.ContainsKey(si.StockItemID) || 
                        stockLevels[si.StockItemID] <= 0);
                }
                else if (stockLevel == "excess")
                {
                    query = query.Where(si => stockLevels.ContainsKey(si.StockItemID) && 
                        stockLevels[si.StockItemID] > 100);
                }
            }

            // Get all stock items with their data
            var stockItems = await query.ToListAsync();

            // Create view models with calculated properties
            var inventoryItems = new List<InventoryItemViewModel>();
            foreach (var item in stockItems)
            {
                var currentStock = stockLevels.ContainsKey(item.StockItemID) ? stockLevels[item.StockItemID] : 0;
                var categories = string.Join(", ", item.StockItemStockGroups.Select(sisg => sisg.StockGroup.StockGroupName));
                
                // Calculate turnover rate (simplified - would need more complex logic for real turnover)
                var turnoverRate = await _context.StockItemTransactions
                    .Where(sit => sit.StockItemID == item.StockItemID && 
                           sit.TransactionOccurredWhen >= DateTime.Now.AddMonths(-3))
                    .SumAsync(sit => Math.Abs(sit.Quantity)) / 3.0m;

                inventoryItems.Add(new InventoryItemViewModel
                {
                    StockItemID = item.StockItemID,
                    StockItemName = item.StockItemName,
                    Categories = categories,
                    CurrentStock = (int)currentStock,
                    UnitPrice = item.UnitPrice,
                    TotalValue = currentStock * item.UnitPrice,
                    TurnoverRate = (double)turnoverRate
                });
            }

            // Apply sorting
            switch (sortBy)
            {
                case "name":
                    inventoryItems = inventoryItems.OrderBy(i => i.StockItemName).ToList();
                    break;
                case "stockLevel":
                    inventoryItems = inventoryItems.OrderBy(i => i.CurrentStock).ToList();
                    break;
                case "value":
                    inventoryItems = inventoryItems.OrderByDescending(i => i.TotalValue).ToList();
                    break;
                case "turnover":
                    inventoryItems = inventoryItems.OrderByDescending(i => i.TurnoverRate).ToList();
                    break;
                default:
                    inventoryItems = inventoryItems.OrderBy(i => i.StockItemName).ToList();
                    break;
            }

            // Calculate summary statistics
            ViewBag.TotalItems = inventoryItems.Count;
            ViewBag.LowStockItems = inventoryItems.Count(i => i.CurrentStock > 0 && i.CurrentStock < 10);
            ViewBag.OutOfStockItems = inventoryItems.Count(i => i.CurrentStock <= 0);
            ViewBag.TotalValue = inventoryItems.Sum(i => i.TotalValue).ToString("C");

            // Get unique categories for the dropdown
            var allCategories = await _context.StockGroups
                .Select(sg => sg.StockGroupName)
                .OrderBy(name => name)
                .ToListAsync();
            ViewBag.Categories = allCategories;

            return View(inventoryItems);
        }

        public IActionResult ShippingReport()
        {
            return View();
        }

        public IActionResult CustomerReport()
        {
            return View();
        }
    }

    public class InventoryItemViewModel
    {
        public int StockItemID { get; set; }
        public string StockItemName { get; set; }
        public string Categories { get; set; }
        public int CurrentStock { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalValue { get; set; }
        public double TurnoverRate { get; set; }
    }
} 
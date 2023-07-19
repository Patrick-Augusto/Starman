using Domain.Entities;
using Infrastructure.Persistence;
using System;

namespace Application.Services
{
    public class StockItemService
    {
        private readonly MyDbContext _context;

        public StockItemService(MyDbContext context)
        {
            _context = context;
        }

        public void AddItem(string name, int quantity, decimal unitPrice)
        {
            StockItem stockItem = new StockItem()
            {
                Name = name,
                Quantity = quantity,
                UnitPrice = unitPrice
            };

            _context.StockItems.Add(stockItem);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Lidar com a exceção (rollback, log, etc.)
                throw;
            }
        }

        public void DeleteItem(int id)
        {
            var stockItem = _context.StockItems.SingleOrDefault(s => s.Id == id);

            if (stockItem != null)
            {
                _context.StockItems.Remove(stockItem);

                try
                {
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    // Lidar com a exceção (rollback, log, etc.)
                    throw;
                }
            }
        }

        public void UpdateItem(int id, string name, int quantity, decimal unitPrice)
        {
            var stockItem = _context.StockItems.SingleOrDefault(s => s.Id == id);

            if (stockItem != null)
            {
                stockItem.Name = name;
                stockItem.Quantity = quantity;
                stockItem.UnitPrice = unitPrice;

                try
                {
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    // Lidar com a exceção (rollback, log, etc.)
                    throw;
                }
            }
        }
    }
}

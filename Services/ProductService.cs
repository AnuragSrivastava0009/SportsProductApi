using Microsoft.EntityFrameworkCore;
using SportsProductApi.Helpers;
using SportsProductApi.Interfaces;
using SportsProductApi.Models;

namespace SportsProductApi.Services
{
    // Service
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _context;
        public ProductService(ProductDbContext context) => _context = context;

        public async Task<Product> CreateProductAsync(Product product)
        {
            product.ProductId = ProductIdGenerator.GenerateUniqueId();
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync() => await _context.Products.ToListAsync();

        public async Task<Product> GetProductByIdAsync(string id) => await _context.Products.FindAsync(id);

        public async Task<bool> DeleteProductAsync(string id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Product> UpdateProductAsync(string id, Product updated)
        {
            var existing = await _context.Products.FindAsync(id);
            if (existing == null) return null;
            existing.Name = updated.Name;
            existing.Description = updated.Description;
            existing.Price = updated.Price;
            existing.StockAvailable = updated.StockAvailable;
            existing.Category = updated.Category;
            existing.Brand = updated.Brand;
            existing.Player = updated.Player;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<Product> DecrementStockAsync(string id, int quantity)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null || product.StockAvailable < quantity) return null;
            product.StockAvailable -= quantity;
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> AddToStockAsync(string id, int quantity)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;
            product.StockAvailable += quantity;
            await _context.SaveChangesAsync();
            return product;
        }
    }

}

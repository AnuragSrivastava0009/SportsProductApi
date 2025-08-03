using SportsProductApi.Models;

namespace SportsProductApi.Interfaces
{
    // Interface
    public interface IProductService
    {
        Task<Product> CreateProductAsync(Product product);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(string id);
        Task<bool> DeleteProductAsync(string id);
        Task<Product> UpdateProductAsync(string id, Product updated);
        Task<Product> DecrementStockAsync(string id, int quantity);
        Task<Product> AddToStockAsync(string id, int quantity);
    }
}

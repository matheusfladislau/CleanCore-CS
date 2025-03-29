using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanCore.Domain.Entities;

public interface IProductRepository {
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product> GetByIdAsync(int? id);
    Task<Product> CreateAsync(Product product);
    Task<Product> RemoveAsync(Product product);
    Task<Product> UpdateAsync(Product product);
    Task<Product> GetProductCategoryAsync(int? id);
    Task<IEnumerable<Product>> GetByCategoryAsync(int? categoryId);
    Task<IEnumerable<Product>> GetBySupplierAsync(int? supplierId);
} 

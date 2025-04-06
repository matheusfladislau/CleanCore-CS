using CleanCore.Application.DTOs;

namespace CleanCore.Application.Interfaces; 
public interface IProductService {
    Task<IEnumerable<ProductDTO>> GetProducts();
    Task<ProductDTO> GetById(int? id);
    Task CreateAsync(ProductDTO product);
    Task RemoveAsync(ProductDTO product);
    Task UpdateAsync(ProductDTO product);

    Task<ProductDTO> GetProductCategory(int? id);
    Task<IEnumerable<ProductDTO>> GetByCategory(int? categoryId);
    Task<IEnumerable<ProductDTO>> GetBySupplier(int? supplierId);
}

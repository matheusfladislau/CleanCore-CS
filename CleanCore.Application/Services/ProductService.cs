using AutoMapper;
using CleanCore.Application.DTOs;
using CleanCore.Application.Interfaces;
using CleanCore.Domain.Entities;

namespace CleanCore.Application.Services;
public class ProductService : IProductService {
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository repository,
        IMapper mapper) {
        this._repository = repository;
        this._mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> GetProducts() {
        var productsEntities = await _repository.GetProductsAsync();
        return _mapper.Map<IEnumerable<ProductDTO>>(productsEntities);
    }

    public async Task<ProductDTO> GetById(int? id) {
        var productEntity = await _repository.GetByIdAsync(id);
        return _mapper.Map<ProductDTO>(productEntity);
    }
    
    public async Task CreateAsync(ProductDTO product) {
        var productEntity = _mapper.Map<Product>(product);
        await _repository.CreateAsync(productEntity);
    }

    public async Task RemoveAsync(ProductDTO product) {
        var productEntity = _mapper.Map<Product>(product);
        await _repository.RemoveAsync(productEntity);
    }

    public async Task UpdateAsync(ProductDTO product) {
        var productEntity = _mapper.Map<Product>(product);
        await _repository.UpdateAsync(productEntity);
    }

    public async Task<IEnumerable<ProductDTO>> GetBySupplier(int? supplierId) {
        var productsEntities = await _repository.GetBySupplierAsync(supplierId);
        return _mapper.Map<IEnumerable<ProductDTO>>(productsEntities);
    }

    public async Task<IEnumerable<ProductDTO>> GetByCategory(int? categoryId) {
        var productsEntities = await _repository.GetByCategoryAsync(categoryId);
        return _mapper.Map<IEnumerable<ProductDTO>>(productsEntities);
    }

    public async Task<ProductDTO> GetProductCategory(int? id) {
        var productEntity = await _repository.GetProductCategoryAsync(id);
        return _mapper.Map<ProductDTO>(productEntity);
    }
}

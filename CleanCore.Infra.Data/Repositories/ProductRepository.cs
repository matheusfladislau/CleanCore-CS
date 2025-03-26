using CleanCore.Domain.Entities;
using CleanCore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
namespace CleanCore.Infra.Data.Repositories;
public class ProductRepository : IProductRepository {
    private ApplicationDbContext _context;
    public ProductRepository(ApplicationDbContext context) {
        this._context = context;
    }

    public async Task<Product> CreateAsync(Product product) {
        _context.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<IEnumerable<Product>> GetByCategoryAsync(int? categoryId) {
        return await _context.Products
            .Where(x => x.CategoryId == categoryId)
            .ToListAsync();
    }

    public async Task<Product> GetByIdAsync(int? id) {
        return await _context.Products.FindAsync(id);
    }

    public async Task<IEnumerable<Product>> GetBySupplierAsync(int? supplierId) {
        return await _context.Products
            .Where(x => x.SupplierId == supplierId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsAsync() {
        return await _context.Products
            .ToListAsync();
    }

    public async Task<Product> GetProductCategoryAsync(int? id) {
        return await _context.Products.Include(x => x.Category)
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Product> RemoveAsync(Product product) {
        _context.Remove(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateAsync(Product product) {
        _context.Update(product);
        await _context.SaveChangesAsync();
        return product;
    }
}

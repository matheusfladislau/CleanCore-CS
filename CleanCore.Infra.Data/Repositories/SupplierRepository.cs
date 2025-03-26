using CleanCore.Domain.Entities;
using CleanCore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanCore.Infra.Data.Repositories; 
public class SupplierRepository : ISupplierRepository {
    private ApplicationDbContext _context;

    public SupplierRepository(ApplicationDbContext context) {
        this._context = context;
    }
    public async Task<Supplier> CreateAsync(Supplier supplier) {
        _context.Add(supplier);
        await _context.SaveChangesAsync();
        return supplier;
    }

    public async Task<Supplier> GetByIdAsync(int? id) {
        return await _context.Suppliers.FindAsync(id);
    }

    public async Task<IEnumerable<Supplier>> GetSuppliersAsync() {
        return await _context.Suppliers.ToListAsync();
    }

    public async Task<Supplier> RemoveAsync(Supplier supplier) {
        _context.Remove(supplier);
        await _context.SaveChangesAsync();
        return supplier;
    }

    public async Task<Supplier> UpdateAsync(Supplier supplier) {
        _context.Update(supplier);
        await _context.SaveChangesAsync();
        return supplier;
    }
}

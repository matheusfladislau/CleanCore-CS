using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanCore.Domain.Entities;

public interface ISupplierRepository {
    Task<IEnumerable<Supplier>> GetSuppliersAsync();
    Task<Supplier> GetByIdAsync(int? id);
    Task<Supplier> CreateAsync(Supplier supplier);
    Task<Supplier> RemoveAsync(Supplier supplier);
    Task<Supplier> UpdateAsync(Supplier supplier);
} 

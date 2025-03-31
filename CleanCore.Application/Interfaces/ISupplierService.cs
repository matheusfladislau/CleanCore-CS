using CleanCore.Application.DTOs;

namespace CleanCore.Application.Interfaces;
public interface ISupplierService {
    Task<IEnumerable<SupplierDTO>> GetSuppliers();
    Task<SupplierDTO> GetById(int? id);

    Task Add(SupplierDTO supplier);
    Task Remove(SupplierDTO supplier);
    Task Update(SupplierDTO supplier);
}

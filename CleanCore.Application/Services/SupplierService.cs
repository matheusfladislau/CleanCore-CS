using AutoMapper;
using CleanCore.Application.DTOs;
using CleanCore.Application.Interfaces;
using CleanCore.Domain.Entities;

namespace CleanCore.Application.Services; 
public class SupplierService : ISupplierService {
    private readonly ISupplierRepository _repository;
    private readonly IMapper _mapper;

    public SupplierService(ISupplierRepository repository,
        IMapper mapper) {
        this._repository = repository;
        this._mapper = mapper;
    }

    public async Task<IEnumerable<SupplierDTO>> GetSuppliers() {
        var suppliersEntities = await _repository.GetSuppliersAsync();
        return _mapper.Map<IEnumerable<SupplierDTO>>(suppliersEntities);
    }

    public async Task<SupplierDTO> GetById(int? id) {
        var supplierEntity = await _repository.GetByIdAsync(id);
        return _mapper.Map<SupplierDTO>(supplierEntity);
    }

    public async Task Add(SupplierDTO supplier) {
        var supplierEntity = _mapper.Map<Supplier>(supplier);
        await _repository.CreateAsync(supplierEntity);
    }

    public async Task Remove(SupplierDTO supplier) {
        var supplierEntity = _mapper.Map<Supplier>(supplier);
        await _repository.RemoveAsync(supplierEntity);
    }

    public async Task Update(SupplierDTO supplier) {
        var supplierEntity = _mapper.Map<Supplier>(supplier);
        await _repository.UpdateAsync(supplierEntity);
    }
}

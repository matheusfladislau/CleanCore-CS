using AutoMapper;
using CleanCore.Application.DTOs;
using CleanCore.Domain.Entities;

namespace CleanCore.Application.Mappings; 
public class SupplierProfile : Profile {
    public SupplierProfile() {
        CreateMap<Supplier, SupplierDTO>().ReverseMap();
    }
}

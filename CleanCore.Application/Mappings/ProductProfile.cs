using AutoMapper;
using CleanCore.Application.DTOs;
using CleanCore.Domain.Entities;

namespace CleanCore.Application.Mappings; 
public class ProductProfile : Profile {
    public ProductProfile() {
        CreateMap<Product, ProductDTO>().ReverseMap();
    }
}

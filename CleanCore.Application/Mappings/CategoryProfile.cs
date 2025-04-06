using AutoMapper;
using CleanCore.Application.DTOs;
using CleanCore.Domain.Entities;

namespace CleanCore.Application.Mappings;
public class CategoryProfile : Profile {
    public CategoryProfile() {
        CreateMap<Category, CategoryDTO>().ReverseMap();
    }
}

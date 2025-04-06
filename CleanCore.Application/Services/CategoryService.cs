using AutoMapper;
using CleanCore.Application.DTOs;
using CleanCore.Application.Interfaces;
using CleanCore.Domain.Entities;

namespace CleanCore.Application.Services;
public class CategoryService : ICategoryService {
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository repository,
        IMapper mapper) {
        
        this._repository = repository;
        this._mapper = mapper;
    }
    
    public async Task<IEnumerable<CategoryDTO>> GetCategories() {
        var categoriesEntity = await _repository.GetCategoriesAsync();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
    }

    public async Task<CategoryDTO> GetById(int? id) {
        var categoryEntity = await _repository.GetByIdAsync(id);
        return _mapper.Map<CategoryDTO>(categoryEntity);
    }

    public async Task Add(CategoryDTO category) {
        var categoryEntity = _mapper.Map<Category>(category);
        await _repository.CreateAsync(categoryEntity);
    }

    public async Task Remove(CategoryDTO category) {
        var categoryEntity = _mapper.Map<Category>(category);
        await _repository.RemoveAsync(categoryEntity);
    }

    public async Task Update(CategoryDTO category) {
        var categoryEntity = _mapper.Map<Category>(category);
        await _repository.UpdateAsync(categoryEntity);
    }
}

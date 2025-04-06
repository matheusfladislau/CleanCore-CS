using CleanCore.Application.DTOs;

namespace CleanCore.Application.Interfaces; 
public interface ICategoryService {
    Task<IEnumerable<CategoryDTO>> GetCategories();
    Task<CategoryDTO> GetById(int? id);

    Task Add(CategoryDTO category);
    Task Remove(CategoryDTO category);
    Task Update(CategoryDTO category);
}

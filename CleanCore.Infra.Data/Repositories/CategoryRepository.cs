﻿using CleanCore.Domain.Entities;
using CleanCore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanCore.Infra.Data.Repositories; 
public class CategoryRepository : ICategoryRepository {
    private ApplicationDbContext _context;
    public CategoryRepository(ApplicationDbContext context) {
        this._context = context;
    }

    public async Task<Category> CreateAsync(Category category) {
        _context.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> GetByIdAsync(int? id) {
        return await _context.Categories.FindAsync(id);
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync() {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category> RemoveAsync(Category category) {
        _context.Remove(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> UpdateAsync(Category category) {
        _context.Update(category);
        await _context.SaveChangesAsync();
        return category;
    }
}

using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class QuestionCategoryRepository : IQuestionCategoryRepository
{
    private readonly AppDbContext _context;

    public QuestionCategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(QuestionCategory category)
    {
        await _context.QuestionCategories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task<QuestionCategory?> GetByIdAsync(Guid id)
    {
        return await _context.QuestionCategories
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<QuestionCategory>> GetListAsync()
    {
        return await _context.QuestionCategories
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task UpdateAsync(QuestionCategory category)
    {
        _context.QuestionCategories.Update(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(QuestionCategory category)
    {
        _context.QuestionCategories.Remove(category);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.QuestionCategories
            .AnyAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsCodeAsync(Guid parishId, string code)
    {
        return await _context.QuestionCategories
            .AnyAsync(x =>
                x.ParishId == parishId &&
                x.Code == code);
    }

    public async Task<bool> ExistsNameAsync(Guid parishId, string name)
    {
        return await _context.QuestionCategories
            .AnyAsync(x =>
                x.ParishId == parishId &&
                x.Name == name);
    }
}
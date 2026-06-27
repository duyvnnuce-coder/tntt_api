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

    public async Task AddAsync(QuestionCategory entity)
    {
        await _context.QuestionCategories.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<QuestionCategory?> GetByIdAsync(Guid id)
    {
        return await _context.QuestionCategories
            .Include(x => x.Parish)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<QuestionCategory>> GetListAsync()
    {
        return await _context.QuestionCategories
            .Include(x => x.Parish)
            .OrderBy(x => x.Code)
            .ToListAsync();
    }

    public async Task UpdateAsync(QuestionCategory entity)
    {
        _context.QuestionCategories.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.QuestionCategories
            .AnyAsync(x => x.Id == id);
    }
}
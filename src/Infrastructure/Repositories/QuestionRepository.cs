using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly AppDbContext _context;

    public QuestionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Question entity)
    {
        await _context.Questions.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<Question?> GetByIdAsync(Guid id)
    {
        return await _context.Questions
            .Include(x => x.QuestionCategory)
            .Include(x => x.CatechismGrade)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Question>> GetListAsync()
    {
        return await _context.Questions
            .Include(x => x.QuestionCategory)
            .Include(x => x.CatechismGrade)
            .OrderBy(x => x.Code)
            .ToListAsync();
    }

    public async Task UpdateAsync(Question entity)
    {
        _context.Questions.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Questions
            .AnyAsync(x => x.Id == id);
    }
}
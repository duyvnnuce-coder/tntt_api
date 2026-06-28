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

    public async Task AddAsync(Question question)
    {
        await _context.Questions.AddAsync(question);
        await _context.SaveChangesAsync();
    }

    public async Task<Question?> GetByIdAsync(Guid id)
    {
        return await _context.Questions
            .Include(x => x.QuestionCategory)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Question>> GetListAsync()
    {
        return await _context.Questions
            .Include(x => x.QuestionCategory)
            .OrderBy(x => x.Code)
            .ToListAsync();
    }

    public async Task UpdateAsync(Question question)
    {
        _context.Questions.Update(question);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Question question)
    {
        _context.Questions.Remove(question);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Questions
            .AnyAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsCodeAsync(string code)
    {
        return await _context.Questions
            .AnyAsync(x => x.Code == code);
    }
}
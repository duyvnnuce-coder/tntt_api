using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ExamScoreRepository : IExamScoreRepository
{
    private readonly AppDbContext _context;

    public ExamScoreRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(ExamScore entity)
    {
        await _context.ExamScores.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<ExamScore?> GetByIdAsync(Guid id)
    {
        return await _context.ExamScores
            .Include(x => x.Exam)
            .Include(x => x.Student)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<ExamScore>> GetListAsync()
    {
        return await _context.ExamScores
            .Include(x => x.Exam)
            .Include(x => x.Student)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
    }

    public async Task UpdateAsync(ExamScore entity)
    {
        _context.ExamScores.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.ExamScores
            .AnyAsync(x => x.Id == id);
    }
}
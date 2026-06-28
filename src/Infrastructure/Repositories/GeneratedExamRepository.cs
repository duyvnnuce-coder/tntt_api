using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GeneratedExamRepository : IGeneratedExamRepository
{
    private readonly AppDbContext _context;

    public GeneratedExamRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(GeneratedExam entity)
    {
        await _context.GeneratedExams.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<GeneratedExam?> GetByIdAsync(Guid id)
    {
        return await _context.GeneratedExams
            .Include(x => x.ExamBlueprint)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<GeneratedExam>> GetListAsync()
    {
        return await _context.GeneratedExams
            .Include(x => x.ExamBlueprint)
            .OrderByDescending(x => x.GeneratedAt)
            .ThenBy(x => x.Code)
            .ToListAsync();
    }

    public async Task UpdateAsync(GeneratedExam entity)
    {
        _context.GeneratedExams.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(GeneratedExam entity)
    {
        _context.GeneratedExams.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.GeneratedExams
            .AnyAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsCodeAsync(string code)
    {
        return await _context.GeneratedExams
            .AnyAsync(x => x.Code == code);
    }
}
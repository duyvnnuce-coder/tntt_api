using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ExamRepository : IExamRepository
{
    private readonly AppDbContext _context;

    public ExamRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Exam entity)
    {
        await _context.Exams.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<Exam?> GetByIdAsync(Guid id)
    {
        return await _context.Exams
            .Include(x => x.Assignment)
                .ThenInclude(x => x.CatechismClass)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Exam>> GetListAsync()
    {
        return await _context.Exams
            .Include(x => x.Assignment)
                 .ThenInclude(x => x.CatechismClass)
            .OrderByDescending(x => x.ExamDate)
            .ThenBy(x => x.Code)
            .ToListAsync();
    }

    public async Task UpdateAsync(Exam entity)
    {
        _context.Exams.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Exams
            .AnyAsync(x => x.Id == id);
    }

    public async Task DeleteAsync(Exam entity)
    {
        _context.Exams.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
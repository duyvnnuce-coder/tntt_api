using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ExamBlueprintDetailRepository : IExamBlueprintDetailRepository
{
    private readonly AppDbContext _context;

    public ExamBlueprintDetailRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(ExamBlueprintDetail entity)
    {
        await _context.ExamBlueprintDetails.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<ExamBlueprintDetail?> GetByIdAsync(Guid id)
    {
        return await _context.ExamBlueprintDetails
            .Include(x => x.ExamBlueprint)
            .Include(x => x.QuestionCategory)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<ExamBlueprintDetail>> GetListAsync()
    {
        return await _context.ExamBlueprintDetails
            .Include(x => x.ExamBlueprint)
            .Include(x => x.QuestionCategory)
            .OrderBy(x => x.QuestionCategory.Name)
            .ToListAsync();
    }

    public async Task UpdateAsync(ExamBlueprintDetail entity)
    {
        _context.ExamBlueprintDetails.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(ExamBlueprintDetail entity)
    {
        _context.ExamBlueprintDetails.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.ExamBlueprintDetails
            .AnyAsync(x => x.Id == id);
    }
}
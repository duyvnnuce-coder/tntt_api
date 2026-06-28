using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ExamBlueprintRepository : IExamBlueprintRepository
{
    private readonly AppDbContext _context;

    public ExamBlueprintRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(ExamBlueprint entity)
    {
        await _context.ExamBlueprints.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<ExamBlueprint?> GetByIdAsync(Guid id)
    {
        return await _context.ExamBlueprints
            .Include(x => x.CatechismGrade)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<ExamBlueprint>> GetListAsync()
    {
        return await _context.ExamBlueprints
            .Include(x => x.CatechismGrade)
            .OrderBy(x => x.Code)
            .ToListAsync();
    }

    public async Task UpdateAsync(ExamBlueprint entity)
    {
        _context.ExamBlueprints.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.ExamBlueprints
            .AnyAsync(x => x.Id == id);
    }

    public async Task DeleteAsync(ExamBlueprint entity)
    {
        _context.ExamBlueprints.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CatechismGradeRepository : ICatechismGradeRepository
{
    private readonly IApplicationDbContext _context;

    public CatechismGradeRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(CatechismGrade grade)
    {
        _context.CatechismGrades.Add(grade);
        await _context.SaveChangesAsync();
    }

    public async Task<List<CatechismGrade>> GetListAsync()
    {
        return await _context.CatechismGrades
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync();
    }

    public async Task<CatechismGrade?> GetByIdAsync(Guid id)
    {
        return await _context.CatechismGrades
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.CatechismGrades
            .AnyAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(CatechismGrade grade)
    {
        _context.CatechismGrades.Update(grade);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(CatechismGrade grade)
    {
        _context.CatechismGrades.Remove(grade);
        await _context.SaveChangesAsync();
    }
}
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CatechismGradeRepository : ICatechismGradeRepository
{
    private readonly AppDbContext _context;

    public CatechismGradeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(CatechismGrade grade)
    {
        await _context.CatechismGrades.AddAsync(grade);
        await _context.SaveChangesAsync();
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
}
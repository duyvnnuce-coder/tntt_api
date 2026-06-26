using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AcademicYearRepository : IAcademicYearRepository
{
    private readonly AppDbContext _context;

    public AcademicYearRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(AcademicYear academicYear)
    {
        await _context.AcademicYears.AddAsync(academicYear);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.AcademicYears.AnyAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsCurrentAsync(Guid parishId)
    {
        return await _context.AcademicYears.AnyAsync(x =>
            x.ParishId == parishId &&
            x.IsCurrent);
    }

    public async Task<AcademicYear?> GetByIdAsync(Guid id)
    {
        return await _context.AcademicYears
            .FirstOrDefaultAsync(x => x.Id == id);
    }


}
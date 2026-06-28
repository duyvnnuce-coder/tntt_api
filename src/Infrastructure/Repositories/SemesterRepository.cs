using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class SemesterRepository : ISemesterRepository
{
    private readonly IApplicationDbContext _context;

    public SemesterRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Semester semester)
    {
        _context.Semesters.Add(semester);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Semester>> GetListAsync()
    {
        return await _context.Semesters
            .OrderBy(x => x.SemesterOrder)
            .ToListAsync();
    }

    public async Task<Semester?> GetByIdAsync(Guid id)
    {
        return await _context.Semesters
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Semesters.AnyAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsCurrentAsync(Guid academicYearId)
    {
        return await _context.Semesters.AnyAsync(x =>
            x.AcademicYearId == academicYearId &&
            x.IsCurrent);
    }

    public async Task UpdateAsync(Semester semester)
    {
        _context.Semesters.Update(semester);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Semester semester)
    {
        _context.Semesters.Remove(semester);
        await _context.SaveChangesAsync();
    }
}
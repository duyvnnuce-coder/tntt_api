using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class SemesterRepository : ISemesterRepository
{
    private readonly AppDbContext _context;

    public SemesterRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Semester semester)
    {
        await _context.Semesters.AddAsync(semester);
        await _context.SaveChangesAsync();
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
}
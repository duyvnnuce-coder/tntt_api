using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AcademicYearRepository : IAcademicYearRepository
{
    private readonly IApplicationDbContext _context;

    public AcademicYearRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        AcademicYear academicYear,
        CancellationToken cancellationToken = default)
    {
        await _context.AcademicYears.AddAsync(
            academicYear,
            cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<AcademicYear?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _context.AcademicYears
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
    }

    public async Task<List<AcademicYear>> GetListAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.AcademicYears
            .OrderByDescending(x => x.StartDate)
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> ExistsAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _context.AcademicYears
            .AnyAsync(
                x => x.Id == id,
                cancellationToken);
    }

    public async Task UpdateAsync(
        AcademicYear academicYear,
        CancellationToken cancellationToken = default)
    {
        _context.AcademicYears.Update(academicYear);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(
        AcademicYear academicYear,
        CancellationToken cancellationToken = default)
    {
        _context.AcademicYears.Remove(academicYear);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
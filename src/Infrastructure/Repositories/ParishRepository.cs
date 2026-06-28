using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ParishRepository : IParishRepository
{
    private readonly IApplicationDbContext _context;

    public ParishRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        Parish parish,
        CancellationToken cancellationToken = default)
    {
        await _context.Parishes.AddAsync(parish, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Parish?> GetByIdAsync(Guid id)
    {
        return await _context.Parishes
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Parish>> GetListAsync()
    {
        return await _context.Parishes
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task UpdateAsync(Parish parish)
    {
        _context.Parishes.Update(parish);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Parish parish)
    {
        _context.Parishes.Remove(parish);

        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _context.Parishes.FindAsync(
            new object[] { id },
            cancellationToken) != null;
    }

    public async Task<Parish?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _context.Parishes
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<List<Parish>> GetListAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.Parishes
            .OrderBy(x => x.Name)
            .ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(
        Parish parish,
        CancellationToken cancellationToken = default)
    {
        _context.Parishes.Update(parish);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(
        Parish parish,
        CancellationToken cancellationToken = default)
    {
        parish.IsActive = false;

        _context.Parishes.Update(parish);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class SacramentRepository : ISacramentRepository
{
    private readonly AppDbContext _context;

    public SacramentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Sacrament sacrament)
    {
        await _context.Sacraments.AddAsync(sacrament);
        await _context.SaveChangesAsync();
    }

    public async Task<Sacrament?> GetByIdAsync(Guid id)
    {
        return await _context.Sacraments
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Sacraments
            .AnyAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsStudentSacramentAsync(
        Guid studentId,
        SacramentType type)
    {
        return await _context.Sacraments.AnyAsync(x =>
            x.StudentId == studentId &&
            x.Type == type);
    }

    public async Task<List<Sacrament>> GetListAsync(Guid? studentId)
    {
        var query = _context.Sacraments.AsQueryable();

        if (studentId.HasValue)
            query = query.Where(x => x.StudentId == studentId.Value);

        return await query
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
    }
}
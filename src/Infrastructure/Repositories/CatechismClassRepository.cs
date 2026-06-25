using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CatechismClassRepository : ICatechismClassRepository
{
    private readonly AppDbContext _context;

    public CatechismClassRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<CatechismClass?> GetByIdAsync(Guid id)
    {
        return await _context.CatechismClasses
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.CatechismClasses
            .AnyAsync(x => x.Id == id);
    }
}
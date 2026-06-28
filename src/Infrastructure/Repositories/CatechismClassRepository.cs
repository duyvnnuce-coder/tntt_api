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

    public async Task AddAsync(CatechismClass catechismClass)
    {
        await _context.CatechismClasses.AddAsync(catechismClass);
        await _context.SaveChangesAsync();
    }

    public async Task<List<CatechismClass>> GetListAsync()
    {
        return await _context.CatechismClasses
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync();
    }

    public async Task UpdateAsync(CatechismClass catechismClass)
    {
        _context.CatechismClasses.Update(catechismClass);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(CatechismClass catechismClass)
    {
        _context.CatechismClasses.Remove(catechismClass);
        await _context.SaveChangesAsync();
    }
}
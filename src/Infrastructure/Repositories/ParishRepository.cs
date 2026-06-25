using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ParishRepository : IParishRepository
{
    private readonly AppDbContext _context;

    public ParishRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Parish?> GetByIdAsync(Guid id)
    {
        return await _context.Parishes
            .FirstOrDefaultAsync(x => x.Id == id);
    }



    public async Task AddAsync(Parish parish)
    {
        await _context.Parishes.AddAsync(parish);
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Parishes
            .AnyAsync(x => x.Id == id);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
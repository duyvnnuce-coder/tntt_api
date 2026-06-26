using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AssistantRepository : IAssistantRepository
{
    private readonly AppDbContext _context;

    public AssistantRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Assistant assistant)
    {
        await _context.Assistants.AddAsync(assistant);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Assistants.AnyAsync(x => x.Id == id);
    }
}
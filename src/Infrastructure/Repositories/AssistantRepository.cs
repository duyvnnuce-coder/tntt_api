using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AssistantRepository : IAssistantRepository
{
    private readonly IApplicationDbContext _context;

    public AssistantRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        Assistant assistant,
        CancellationToken cancellationToken = default)
    {
        await _context.Assistants.AddAsync(
            assistant,
            cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Assistant?> GetByIdAsync(Guid id)
    {
        return await _context.Assistants
            .Include(x => x.Parish)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Assistant>> GetListAsync()
    {
        return await _context.Assistants
            .OrderBy(x => x.FullName)
            .ToListAsync();
    }

    public async Task UpdateAsync(Assistant assistant)
    {
        _context.Assistants.Update(assistant);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Assistant assistant)
    {
        _context.Assistants.Remove(assistant);

        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _context.Assistants.FindAsync(
            new object[] { id },
            cancellationToken) != null;
    }
}
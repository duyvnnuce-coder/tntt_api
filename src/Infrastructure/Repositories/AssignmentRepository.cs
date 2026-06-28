using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AssignmentRepository : IAssignmentRepository
{
    private readonly AppDbContext _context;

    public AssignmentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Assignment assignment)
    {
        await _context.Assignments.AddAsync(assignment);
        await _context.SaveChangesAsync();
    }

    public async Task<Assignment?> GetByIdAsync(Guid id)
    {
        return await _context.Assignments
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Assignments
            .AnyAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsDuplicateAsync(
        Guid semesterId,
        Guid catechismClassId,
        Guid teacherId)
    {
        return await _context.Assignments.AnyAsync(x =>
            x.SemesterId == semesterId &&
            x.CatechismClassId == catechismClassId &&
            x.TeacherId == teacherId);
    }

    public async Task<List<Assignment>> GetListAsync()
    {
        return await _context.Assignments
            .OrderBy(x => x.StartDate)
            .ToListAsync();
    }

    public async Task UpdateAsync(Assignment assignment)
    {
        _context.Assignments.Update(assignment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Assignment assignment)
    {
        _context.Assignments.Remove(assignment);
        await _context.SaveChangesAsync();
    }
}
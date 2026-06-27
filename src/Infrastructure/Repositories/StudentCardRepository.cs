using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class StudentCardRepository : IStudentCardRepository
{
    private readonly AppDbContext _context;

    public StudentCardRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(StudentCard studentCard)
    {
        await _context.StudentCards.AddAsync(studentCard);
        await _context.SaveChangesAsync();
    }

    public async Task<StudentCard?> GetByIdAsync(Guid id)
    {
        return await _context.StudentCards
            .Include(x => x.Student)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<StudentCard?> GetByStudentIdAsync(Guid studentId)
    {
        return await _context.StudentCards
            .Include(x => x.Student)
            .FirstOrDefaultAsync(x => x.StudentId == studentId);
    }

    public async Task<List<StudentCard>> GetListAsync()
    {
        return await _context.StudentCards
            .Include(x => x.Student)
            .OrderBy(x => x.CardNumber)
            .ToListAsync();
    }

    public async Task UpdateAsync(StudentCard studentCard)
    {
        _context.StudentCards.Update(studentCard);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.StudentCards
            .AnyAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsByStudentIdAsync(Guid studentId)
    {
        return await _context.StudentCards
            .AnyAsync(x => x.StudentId == studentId);
    }
}
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly IApplicationDbContext _context;

    public async Task<Teacher?> GetByIdAsync(Guid id)
    {
        return await _context.Teachers.FindAsync(id);
    }

    public async Task<List<Teacher>> GetListAsync()
    {
        return await _context.Teachers
            .OrderBy(x => x.Code)
            .ToListAsync();
    }

    public TeacherRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        Teacher teacher,
        CancellationToken cancellationToken = default)
    {
        await _context.Teachers.AddAsync(teacher, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(
        Teacher teacher,
        CancellationToken cancellationToken = default)
    {
        _context.Teachers.Update(teacher);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(
        Teacher teacher,
        CancellationToken cancellationToken = default)
    {
        teacher.IsDeleted = true;

        _context.Teachers.Update(teacher);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> ExistsAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _context.Teachers.FindAsync(
            new object[] { id },
            cancellationToken) != null;
    }
}
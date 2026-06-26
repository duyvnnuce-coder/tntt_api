using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly IApplicationDbContext _context;

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

    public async Task<bool> ExistsAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _context.Teachers.FindAsync(
            new object[] { id },
            cancellationToken) != null;
    }
}
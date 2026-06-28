using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class StudentEnrollmentRepository : IStudentEnrollmentRepository
{
    private readonly IApplicationDbContext _context;

    public StudentEnrollmentRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(StudentEnrollment enrollment)
    {
        _context.StudentEnrollments.Add(enrollment);
        await _context.SaveChangesAsync();
    }

    public async Task<StudentEnrollment?> GetByIdAsync(Guid id)
    {
        return await _context.StudentEnrollments
            .Include(x => x.Student)
            .Include(x => x.CatechismClass)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<StudentEnrollment>> GetListAsync()
    {
        return await _context.StudentEnrollments
            .Include(x => x.Student)
            .Include(x => x.CatechismClass)
            .OrderBy(x => x.JoinDate)
            .ToListAsync();
    }

    public async Task<StudentEnrollment?> GetCurrentByStudentIdAsync(Guid studentId)
    {
        return await _context.StudentEnrollments
            .Include(x => x.Student)
            .Include(x => x.CatechismClass)
            .FirstOrDefaultAsync(x =>
                x.StudentId == studentId &&
                x.IsCurrent);
    }

    public async Task<bool> ExistsCurrentAsync(Guid studentId)
    {
        return await _context.StudentEnrollments
            .AnyAsync(x =>
                x.StudentId == studentId &&
                x.IsCurrent);
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.StudentEnrollments
            .AnyAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(StudentEnrollment enrollment)
    {
        _context.StudentEnrollments.Update(enrollment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(StudentEnrollment enrollment)
    {
        _context.StudentEnrollments.Remove(enrollment);
        await _context.SaveChangesAsync();
    }
}
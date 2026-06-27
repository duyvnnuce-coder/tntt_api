using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class StudentEnrollmentRepository : IStudentEnrollmentRepository
{
    private readonly AppDbContext _context;

    public StudentEnrollmentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(StudentEnrollment enrollment)
    {
        await _context.StudentEnrollments.AddAsync(enrollment);
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
            .OrderByDescending(x => x.JoinDate)
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

    public async Task UpdateAsync(StudentEnrollment enrollment)
    {
        _context.StudentEnrollments.Update(enrollment);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.StudentEnrollments
            .AnyAsync(x => x.Id == id);
    }
}
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;

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
    }
}
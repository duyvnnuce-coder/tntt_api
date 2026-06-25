using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _context;

    public StudentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Student?> GetByIdAsync(Guid id)
    {
        return await _context.Students
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Student?> GetByCodeAsync(string code)
    {
        return await _context.Students
            .FirstOrDefaultAsync(x => x.Code == code);
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Students
            .AnyAsync(x => x.Id == id);
    }

    public async Task AddAsync(
        Student student,
        StudentEnrollment enrollment,
        StudentCard studentCard)
    {
        await _context.Students.AddAsync(student);
        await _context.StudentEnrollments.AddAsync(enrollment);
        await _context.StudentCards.AddAsync(studentCard);

        await _context.SaveChangesAsync();
    }
}
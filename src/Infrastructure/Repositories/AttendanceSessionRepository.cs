using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AttendanceSessionRepository : IAttendanceSessionRepository
{
    private readonly AppDbContext _context;

    public AttendanceSessionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(AttendanceSession attendanceSession)
    {
        await _context.AttendanceSessions.AddAsync(attendanceSession);
        await _context.SaveChangesAsync();
    }

    public async Task<AttendanceSession?> GetByIdAsync(Guid id)
    {
        return await _context.AttendanceSessions
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.AttendanceSessions
            .AnyAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsDuplicateAsync(
        Guid assignmentId,
        DateOnly attendanceDate,
        int lessonNumber)
    {
        return await _context.AttendanceSessions.AnyAsync(x =>
            x.AssignmentId == assignmentId &&
            x.AttendanceDate == attendanceDate &&
            x.LessonNumber == lessonNumber);
    }
}
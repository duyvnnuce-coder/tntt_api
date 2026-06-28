using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AttendanceSessionRepository : IAttendanceSessionRepository
{
    private readonly IApplicationDbContext _context;

    public AttendanceSessionRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(AttendanceSession attendanceSession)
    {
        _context.AttendanceSessions.Add(attendanceSession);
        await _context.SaveChangesAsync();
    }

    public async Task<List<AttendanceSession>> GetListAsync()
    {
        return await _context.AttendanceSessions
            .OrderBy(x => x.AttendanceDate)
            .ThenBy(x => x.LessonNumber)
            .ToListAsync();
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

    public async Task UpdateAsync(AttendanceSession attendanceSession)
    {
        _context.AttendanceSessions.Update(attendanceSession);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(AttendanceSession attendanceSession)
    {
        _context.AttendanceSessions.Remove(attendanceSession);
        await _context.SaveChangesAsync();
    }
}
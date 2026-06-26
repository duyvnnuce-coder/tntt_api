using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AttendanceRepository : IAttendanceRepository
{
    private readonly AppDbContext _context;

    public AttendanceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Attendance attendance)
    {
        await _context.Attendances.AddAsync(attendance);
        await _context.SaveChangesAsync();
    }

    public async Task<Attendance?> GetByIdAsync(Guid id)
    {
        return await _context.Attendances
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Attendances
            .AnyAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsAsync(
        Guid attendanceSessionId,
        Guid studentId)
    {
        return await _context.Attendances.AnyAsync(x =>
            x.AttendanceSessionId == attendanceSessionId &&
            x.StudentId == studentId);
    }
}
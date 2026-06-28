using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AttendanceRepository : IAttendanceRepository
{
    private readonly IApplicationDbContext _context;

    public AttendanceRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Attendance attendance)
    {
        _context.Attendances.Add(attendance);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Attendance>> GetListAsync()
    {
        return await _context.Attendances
            .OrderBy(x => x.AttendanceSessionId)
            .ThenBy(x => x.StudentId)
            .ToListAsync();
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

    public async Task UpdateAsync(Attendance attendance)
    {
        _context.Attendances.Update(attendance);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Attendance attendance)
    {
        _context.Attendances.Remove(attendance);
        await _context.SaveChangesAsync();
    }
}
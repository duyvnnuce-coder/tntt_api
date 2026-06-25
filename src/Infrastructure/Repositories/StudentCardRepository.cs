using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories;

public class StudentCardRepository : IStudentCardRepository
{
    private readonly AppDbContext _context;

    public StudentCardRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(StudentCard studentCard)
    {
        await _context.StudentCards.AddAsync(studentCard);
    }
}
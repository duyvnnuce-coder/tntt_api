using Domain.Entities;

namespace Domain.Interfaces;

public interface IStudentCardRepository
{
    Task AddAsync(StudentCard studentCard);
}
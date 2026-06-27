using Domain.Entities;

namespace Domain.Interfaces;

public interface ISacramentRepository
{
    Task AddAsync(Sacrament sacrament);

    Task<Sacrament?> GetByIdAsync(Guid id);

    Task<bool> ExistsAsync(Guid id);

    Task<bool> ExistsStudentSacramentAsync(
        Guid studentId,
        SacramentType type);

    Task<List<Sacrament>> GetListAsync(Guid? studentId);
}
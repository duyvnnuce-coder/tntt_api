namespace Domain.Interfaces;

public interface IRepositoryContext
{
    Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default);
}
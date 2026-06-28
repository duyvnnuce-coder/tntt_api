using Domain.Interfaces;

namespace Application.Features.Parishes.DeleteParish;

public class DeleteParishHandler
{
    private readonly IParishRepository _repository;

    public DeleteParishHandler(
        IParishRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(Guid id)
    {
        var parish = await _repository.GetByIdAsync(id);

        if (parish is null)
            throw new Exception("Không tìm thấy giáo xứ.");

        await _repository.DeleteAsync(parish);
    }
}
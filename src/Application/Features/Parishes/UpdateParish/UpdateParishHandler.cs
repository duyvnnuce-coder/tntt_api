using Domain.Interfaces;

namespace Application.Features.Parishes.UpdateParish;

public class UpdateParishHandler
{
    private readonly IParishRepository _repository;

    public UpdateParishHandler(
        IParishRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateParishRequest request)
    {
        var parish = await _repository.GetByIdAsync(request.Id);

        if (parish is null)
            throw new Exception("Không tìm thấy giáo xứ.");

        parish.Name = request.Name;
        parish.Address = request.Address;
        parish.Phone = request.Phone;
        parish.Description = request.Description;
        parish.IsActive = request.IsActive;

        await _repository.UpdateAsync(parish);
    }
}
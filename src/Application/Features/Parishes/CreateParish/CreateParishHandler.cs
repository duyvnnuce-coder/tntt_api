using Domain.Entities;
using Domain.Interfaces;

namespace Application.Features.Parishes.CreateParish;

public class CreateParishHandler
{
    private readonly IParishRepository _parishRepository;

    public CreateParishHandler(IParishRepository parishRepository)
    {
        _parishRepository = parishRepository;
    }

    public async Task<CreateParishResult> Handle(CreateParishCommand request)
    {
        var parish = new Parish
        {
            Name = request.Name,
            Address = request.Address,
            Phone = request.Phone,
            Description = request.Description
        };

        await _parishRepository.AddAsync(parish);
        await _parishRepository.SaveChangesAsync();

        return new CreateParishResult
        {
            Success = true,
            Message = "Tạo giáo xứ thành công.",
            Data = new CreateParishResponse
            {
                Id = parish.Id,
                Name = parish.Name
            }
        };
    }
}
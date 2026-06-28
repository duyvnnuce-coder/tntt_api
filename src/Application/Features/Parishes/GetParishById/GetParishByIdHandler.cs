using Domain.Interfaces;

namespace Application.Features.Parishes.GetParishById;

public class GetParishByIdHandler
{
    private readonly IParishRepository _repository;

    public GetParishByIdHandler(IParishRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetParishByIdResult> Handle(GetParishByIdRequest request)
    {
        var parish = await _repository.GetByIdAsync(request.Id);

        if (parish is null)
        {
            return new GetParishByIdResult
            {
                Success = false,
                Message = "Không tìm thấy giáo xứ."
            };
        }

        return new GetParishByIdResult
        {
            Success = true,
            Message = "Thành công.",
            Data = new GetParishByIdResponse
            {
                Id = parish.Id,
                Code = parish.Code,
                Name = parish.Name,

                Address = parish.Address,
                Phone = parish.Phone,

                IsActive = parish.IsActive
            }
        };
    }
}
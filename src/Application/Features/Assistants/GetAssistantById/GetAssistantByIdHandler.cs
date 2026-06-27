using Domain.Interfaces;

namespace Application.Features.Assistants.GetAssistantById;

public class GetAssistantByIdHandler
{
    private readonly IAssistantRepository _repository;

    public GetAssistantByIdHandler(
        IAssistantRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetAssistantByIdResult> Handle(GetAssistantByIdRequest request)
    {
        var assistant = await _repository.GetByIdAsync(request.Id);

        if (assistant is null)
        {
            return new GetAssistantByIdResult
            {
                Success = false,
                Message = "Không tìm thấy trợ giảng."
            };
        }

        return new GetAssistantByIdResult
        {
            Success = true,
            Message = "Lấy thông tin trợ giảng thành công.",
            Data = new GetAssistantByIdResponse
            {
                Id = assistant.Id,
                ParishId = assistant.ParishId,
                Code = assistant.Code,
                ChristianName = assistant.ChristianName,
                FullName = assistant.FullName,
                DateOfBirth = assistant.DateOfBirth,
                Gender = assistant.Gender,
                Phone = assistant.Phone,
                Email = assistant.Email,
                Address = assistant.Address,
                JoinDate = assistant.JoinDate,
                IsActive = assistant.IsActive
            }
        };
    }
}
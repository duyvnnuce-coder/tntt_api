using Domain.Interfaces;

namespace Application.Features.Assistants.UpdateAssistant;

public class UpdateAssistantHandler
{
    private readonly IAssistantRepository _repository;

    public UpdateAssistantHandler(
        IAssistantRepository repository)
    {
        _repository = repository;
    }

    public async Task<UpdateAssistantResult> Handle(UpdateAssistantRequest request)
    {
        var assistant = await _repository.GetByIdAsync(request.Id);

        if (assistant is null)
        {
            return new UpdateAssistantResult
            {
                Success = false,
                Message = "Không tìm thấy trợ giảng."
            };
        }

        assistant.ChristianName = request.ChristianName;
        assistant.FullName = request.FullName;
        assistant.DateOfBirth = request.DateOfBirth;
        assistant.Gender = request.Gender;
        assistant.Phone = request.Phone;
        assistant.Email = request.Email;
        assistant.Address = request.Address;
        assistant.JoinDate = request.JoinDate;
        assistant.IsActive = request.IsActive;

        await _repository.UpdateAsync(assistant);

        return new UpdateAssistantResult
        {
            Success = true,
            Message = "Cập nhật trợ giảng thành công."
        };
    }
}
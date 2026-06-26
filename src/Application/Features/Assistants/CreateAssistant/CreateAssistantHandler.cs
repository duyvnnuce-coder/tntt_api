using Application.Common.Enums;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Features.Assistants.CreateAssistant;

public class CreateAssistantHandler
{
    private readonly IAssistantRepository _assistantRepository;
    private readonly IParishRepository _parishRepository;
    private readonly ICodeGenerator _codeGenerator;

    public CreateAssistantHandler(
        IAssistantRepository assistantRepository,
        IParishRepository parishRepository,
        ICodeGenerator codeGenerator)
    {
        _assistantRepository = assistantRepository;
        _parishRepository = parishRepository;
        _codeGenerator = codeGenerator;
    }

    public async Task<CreateAssistantResult> Handle(
        CreateAssistantRequest request,
        CancellationToken cancellationToken = default)
    {
        if (!await _parishRepository.ExistsAsync(request.ParishId))
        {
            return new CreateAssistantResult
            {
                Success = false,
                Message = "Giáo xứ không tồn tại."
            };
        }

        var code = await _codeGenerator.GenerateAsync(
            CodeType.Assistant,
            request.ParishId,
            cancellationToken);

        var assistant = new Assistant
        {
            ParishId = request.ParishId,
            Code = code,
            ChristianName = request.ChristianName ?? string.Empty,
            FullName = request.FullName,
            DateOfBirth = request.DateOfBirth,
            Gender = request.Gender,
            Phone = request.Phone,
            Email = request.Email,
            Address = request.Address,
            JoinDate = request.JoinDate
        };

        await _assistantRepository.AddAsync(assistant);

        return new CreateAssistantResult
        {
            Success = true,
            Message = "Tạo trợ tá thành công.",
            Data = new CreateAssistantResponse
            {
                Id = assistant.Id,
                Code = assistant.Code,
                FullName = assistant.FullName
            }
        };
    }
}
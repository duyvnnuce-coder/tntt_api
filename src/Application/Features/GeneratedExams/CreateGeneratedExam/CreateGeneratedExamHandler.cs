using Application.Common.Enums;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Features.GeneratedExams.CreateGeneratedExam;

public class CreateGeneratedExamHandler
{
    private readonly IGeneratedExamRepository _repository;
    private readonly IExamBlueprintRepository _examBlueprintRepository;
    private readonly ICodeGenerator _codeGenerator;

    public CreateGeneratedExamHandler(
        IGeneratedExamRepository repository,
        IExamBlueprintRepository examBlueprintRepository,
        ICodeGenerator codeGenerator)
    {
        _repository = repository;
        _examBlueprintRepository = examBlueprintRepository;
        _codeGenerator = codeGenerator;
    }

    public async Task<CreateGeneratedExamResult> Handle(
        CreateGeneratedExamRequest request)
    {
        var validation = CreateGeneratedExamValidator.Validate(request);

        if (validation is not null)
        {
            return new CreateGeneratedExamResult
            {
                Success = false,
                Message = validation
            };
        }

        var blueprint = await _examBlueprintRepository.GetByIdAsync(request.ExamBlueprintId);

        if (blueprint is null)
        {
            return new CreateGeneratedExamResult
            {
                Success = false,
                Message = "Không tìm thấy đề mẫu."
            };
        }

        var code = await _codeGenerator.GenerateAsync(
            CodeType.GeneratedExam,
            Guid.Empty);

        var entity = new GeneratedExam
        {
            ExamBlueprintId = request.ExamBlueprintId,
            Code = code,
            Name = request.Name,
            GeneratedAt = DateTime.Now,
            IsPublished = request.IsPublished
        };

        await _repository.AddAsync(entity);

        return new CreateGeneratedExamResult
        {
            Success = true,
            Message = "Tạo đề thi thành công.",
            Data = new CreateGeneratedExamResponse
            {
                Id = entity.Id,
                Code = entity.Code
            }
        };
    }
}
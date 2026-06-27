using Domain.Entities;
using Domain.Interfaces;

namespace Application.Features.GeneratedExams.CreateGeneratedExam;

public class CreateGeneratedExamHandler
{
    private readonly IGeneratedExamRepository _repository;
    private readonly IExamBlueprintRepository _examBlueprintRepository;

    public CreateGeneratedExamHandler(
        IGeneratedExamRepository repository,
        IExamBlueprintRepository examBlueprintRepository)
    {
        _repository = repository;
        _examBlueprintRepository = examBlueprintRepository;
    }

    public async Task<CreateGeneratedExamResult> Handle(
        CreateGeneratedExamRequest request)
    {
        var errors =
            CreateGeneratedExamValidator.Validate(request);

        if (errors.Any())
        {
            return new CreateGeneratedExamResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var blueprint =
            await _examBlueprintRepository.GetByIdAsync(
                request.ExamBlueprintId);

        if (blueprint == null)
        {
            return new CreateGeneratedExamResult
            {
                Success = false,
                Message = "Exam blueprint not found."
            };
        }

        var entity = new GeneratedExam
        {
            ExamBlueprintId = request.ExamBlueprintId,
            Code = request.Code.Trim(),
            Name = request.Name.Trim(),
            GeneratedAt = request.GeneratedAt,
            IsPublished = request.IsPublished
        };

        await _repository.AddAsync(entity);

        return new CreateGeneratedExamResult
        {
            Success = true,
            Message = "Generated exam created successfully.",
            Data = new CreateGeneratedExamResponse
            {
                Id = entity.Id,
                ExamBlueprintId = entity.ExamBlueprintId,
                ExamBlueprintCode = blueprint.Code,
                Code = entity.Code,
                Name = entity.Name,
                GeneratedAt = entity.GeneratedAt,
                IsPublished = entity.IsPublished
            }
        };
    }
}
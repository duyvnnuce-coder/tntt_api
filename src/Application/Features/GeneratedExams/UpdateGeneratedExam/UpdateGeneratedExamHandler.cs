using Domain.Interfaces;

namespace Application.Features.GeneratedExams.UpdateGeneratedExam;

public class UpdateGeneratedExamHandler
{
    private readonly IGeneratedExamRepository _repository;
    private readonly IExamBlueprintRepository _examBlueprintRepository;

    public UpdateGeneratedExamHandler(
        IGeneratedExamRepository repository,
        IExamBlueprintRepository examBlueprintRepository)
    {
        _repository = repository;
        _examBlueprintRepository = examBlueprintRepository;
    }

    public async Task<UpdateGeneratedExamResult> Handle(
        UpdateGeneratedExamRequest request)
    {
        var errors =
            UpdateGeneratedExamValidator.Validate(request);

        if (errors.Any())
        {
            return new UpdateGeneratedExamResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity == null)
        {
            return new UpdateGeneratedExamResult
            {
                Success = false,
                Message = "Generated exam not found."
            };
        }

        var blueprint =
            await _examBlueprintRepository.GetByIdAsync(
                request.ExamBlueprintId);

        if (blueprint == null)
        {
            return new UpdateGeneratedExamResult
            {
                Success = false,
                Message = "Exam blueprint not found."
            };
        }

        entity.ExamBlueprintId = request.ExamBlueprintId;
        entity.Code = request.Code.Trim();
        entity.Name = request.Name.Trim();
        entity.GeneratedAt = request.GeneratedAt;
        entity.IsPublished = request.IsPublished;

        await _repository.UpdateAsync(entity);

        return new UpdateGeneratedExamResult
        {
            Success = true,
            Message = "Generated exam updated successfully.",
            Data = new UpdateGeneratedExamResponse
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
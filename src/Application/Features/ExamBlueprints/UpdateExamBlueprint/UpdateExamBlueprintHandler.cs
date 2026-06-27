using Domain.Interfaces;

namespace Application.Features.ExamBlueprints.UpdateExamBlueprint;

public class UpdateExamBlueprintHandler
{
    private readonly IExamBlueprintRepository _repository;
    private readonly ICatechismGradeRepository _gradeRepository;

    public UpdateExamBlueprintHandler(
        IExamBlueprintRepository repository,
        ICatechismGradeRepository gradeRepository)
    {
        _repository = repository;
        _gradeRepository = gradeRepository;
    }

    public async Task<UpdateExamBlueprintResult> Handle(
        UpdateExamBlueprintRequest request)
    {
        var errors =
            UpdateExamBlueprintValidator.Validate(request);

        if (errors.Any())
        {
            return new UpdateExamBlueprintResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity == null)
        {
            return new UpdateExamBlueprintResult
            {
                Success = false,
                Message = "Exam blueprint not found."
            };
        }

        var grade = await _gradeRepository.GetByIdAsync(
            request.CatechismGradeId);

        if (grade == null)
        {
            return new UpdateExamBlueprintResult
            {
                Success = false,
                Message = "Catechism grade not found."
            };
        }

        entity.CatechismGradeId = request.CatechismGradeId;
        entity.Code = request.Code.Trim();
        entity.Name = request.Name.Trim();
        entity.TotalQuestions = request.TotalQuestions;
        entity.DurationMinutes = request.DurationMinutes;
        entity.IsActive = request.IsActive;

        await _repository.UpdateAsync(entity);

        return new UpdateExamBlueprintResult
        {
            Success = true,
            Message = "Exam blueprint updated successfully.",
            Data = new UpdateExamBlueprintResponse
            {
                Id = entity.Id,
                CatechismGradeId = entity.CatechismGradeId,
                CatechismGradeCode = grade.Code,
                CatechismGradeName = grade.Name,
                Code = entity.Code,
                Name = entity.Name,
                TotalQuestions = entity.TotalQuestions,
                DurationMinutes = entity.DurationMinutes,
                IsActive = entity.IsActive
            }
        };
    }
}
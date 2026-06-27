using Domain.Entities;
using Domain.Interfaces;

namespace Application.Features.ExamBlueprints.CreateExamBlueprint;

public class CreateExamBlueprintHandler
{
    private readonly IExamBlueprintRepository _repository;
    private readonly ICatechismGradeRepository _gradeRepository;

    public CreateExamBlueprintHandler(
        IExamBlueprintRepository repository,
        ICatechismGradeRepository gradeRepository)
    {
        _repository = repository;
        _gradeRepository = gradeRepository;
    }

    public async Task<CreateExamBlueprintResult> Handle(
        CreateExamBlueprintRequest request)
    {
        var errors = CreateExamBlueprintValidator.Validate(request);

        if (errors.Any())
        {
            return new CreateExamBlueprintResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var grade = await _gradeRepository.GetByIdAsync(
            request.CatechismGradeId);

        if (grade == null)
        {
            return new CreateExamBlueprintResult
            {
                Success = false,
                Message = "Catechism grade not found."
            };
        }

        var entity = new ExamBlueprint
        {
            CatechismGradeId = request.CatechismGradeId,
            Code = request.Code.Trim(),
            Name = request.Name.Trim(),
            TotalQuestions = request.TotalQuestions,
            DurationMinutes = request.DurationMinutes,
            IsActive = request.IsActive
        };

        await _repository.AddAsync(entity);

        return new CreateExamBlueprintResult
        {
            Success = true,
            Message = "Exam blueprint created successfully.",
            Data = new CreateExamBlueprintResponse
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
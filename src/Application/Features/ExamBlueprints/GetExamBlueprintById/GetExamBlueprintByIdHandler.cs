using Domain.Interfaces;

namespace Application.Features.ExamBlueprints.GetExamBlueprintById;

public class GetExamBlueprintByIdHandler
{
    private readonly IExamBlueprintRepository _repository;

    public GetExamBlueprintByIdHandler(
        IExamBlueprintRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetExamBlueprintByIdResult> Handle(
        GetExamBlueprintByIdRequest request)
    {
        var errors =
            GetExamBlueprintByIdValidator.Validate(request);

        if (errors.Any())
        {
            return new GetExamBlueprintByIdResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity == null)
        {
            return new GetExamBlueprintByIdResult
            {
                Success = false,
                Message = "Exam blueprint not found."
            };
        }

        return new GetExamBlueprintByIdResult
        {
            Success = true,
            Message = "Success.",
            Data = new GetExamBlueprintByIdResponse
            {
                Id = entity.Id,
                CatechismGradeId = entity.CatechismGradeId,
                CatechismGradeCode = entity.CatechismGrade.Code,
                CatechismGradeName = entity.CatechismGrade.Name,
                Code = entity.Code,
                Name = entity.Name,
                TotalQuestions = entity.TotalQuestions,
                DurationMinutes = entity.DurationMinutes,
                IsActive = entity.IsActive
            }
        };
    }
}
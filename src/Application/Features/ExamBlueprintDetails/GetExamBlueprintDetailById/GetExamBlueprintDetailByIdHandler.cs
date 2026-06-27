using Domain.Interfaces;

namespace Application.Features.ExamBlueprintDetails.GetExamBlueprintDetailById;

public class GetExamBlueprintDetailByIdHandler
{
    private readonly IExamBlueprintDetailRepository _repository;

    public GetExamBlueprintDetailByIdHandler(
        IExamBlueprintDetailRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetExamBlueprintDetailByIdResult> Handle(
        GetExamBlueprintDetailByIdRequest request)
    {
        var errors =
            GetExamBlueprintDetailByIdValidator.Validate(request);

        if (errors.Any())
        {
            return new GetExamBlueprintDetailByIdResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity == null)
        {
            return new GetExamBlueprintDetailByIdResult
            {
                Success = false,
                Message = "Exam blueprint detail not found."
            };
        }

        return new GetExamBlueprintDetailByIdResult
        {
            Success = true,
            Message = "Success.",
            Data = new GetExamBlueprintDetailByIdResponse
            {
                Id = entity.Id,
                ExamBlueprintId = entity.ExamBlueprintId,
                ExamBlueprintCode = entity.ExamBlueprint.Code,
                ExamBlueprintName = entity.ExamBlueprint.Name,
                QuestionCategoryId = entity.QuestionCategoryId,
                QuestionCategoryCode = entity.QuestionCategory.Code,
                QuestionCategoryName = entity.QuestionCategory.Name,
                EasyQuestions = entity.EasyQuestions,
                MediumQuestions = entity.MediumQuestions,
                HardQuestions = entity.HardQuestions
            }
        };
    }
}
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
        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity is null)
        {
            return new GetExamBlueprintDetailByIdResult
            {
                Success = false,
                Message = "Không tìm thấy chi tiết ma trận đề."
            };
        }

        return new GetExamBlueprintDetailByIdResult
        {
            Success = true,
            Message = "Lấy chi tiết ma trận đề thành công.",
            Data = new GetExamBlueprintDetailByIdResponse
            {
                Id = entity.Id,

                ExamBlueprintId = entity.ExamBlueprintId,
                ExamBlueprintName = entity.ExamBlueprint.Name,

                QuestionCategoryId = entity.QuestionCategoryId,
                QuestionCategoryName = entity.QuestionCategory.Name,

                EasyQuestions = entity.EasyQuestions,
                MediumQuestions = entity.MediumQuestions,
                HardQuestions = entity.HardQuestions
            }
        };
    }
}
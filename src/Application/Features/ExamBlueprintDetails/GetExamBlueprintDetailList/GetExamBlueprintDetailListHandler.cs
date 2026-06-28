using Domain.Interfaces;

namespace Application.Features.ExamBlueprintDetails.GetExamBlueprintDetailList;

public class GetExamBlueprintDetailListHandler
{
    private readonly IExamBlueprintDetailRepository _repository;

    public GetExamBlueprintDetailListHandler(
        IExamBlueprintDetailRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetExamBlueprintDetailListResult> Handle(
        GetExamBlueprintDetailListRequest request)
    {
        var list = await _repository.GetListAsync();

        return new GetExamBlueprintDetailListResult
        {
            Success = true,
            Message = "Lấy danh sách thành công.",
            Data = list.Select(x => new GetExamBlueprintDetailListResponse
            {
                Id = x.Id,
                ExamBlueprintName = x.ExamBlueprint.Name,
                QuestionCategoryName = x.QuestionCategory.Name,
                EasyQuestions = x.EasyQuestions,
                MediumQuestions = x.MediumQuestions,
                HardQuestions = x.HardQuestions
            }).ToList()
        };
    }
}
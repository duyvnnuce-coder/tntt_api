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
        var errors =
            GetExamBlueprintDetailListValidator.Validate(request);

        if (errors.Any())
        {
            return new GetExamBlueprintDetailListResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var data = await _repository.GetListAsync();

        if (request.ExamBlueprintId.HasValue)
        {
            data = data.Where(x =>
                    x.ExamBlueprintId == request.ExamBlueprintId.Value)
                .ToList();
        }

        if (request.QuestionCategoryId.HasValue)
        {
            data = data.Where(x =>
                    x.QuestionCategoryId == request.QuestionCategoryId.Value)
                .ToList();
        }

        if (!string.IsNullOrWhiteSpace(request.Keyword))
        {
            var keyword = request.Keyword.Trim().ToLower();

            data = data.Where(x =>
                    x.ExamBlueprint.Code.ToLower().Contains(keyword)
                    || x.ExamBlueprint.Name.ToLower().Contains(keyword)
                    || x.QuestionCategory.Code.ToLower().Contains(keyword)
                    || x.QuestionCategory.Name.ToLower().Contains(keyword))
                .ToList();
        }

        return new GetExamBlueprintDetailListResult
        {
            Success = true,
            Message = "Success.",
            Data = data.Select(x => new GetExamBlueprintDetailListResponse
            {
                Id = x.Id,
                ExamBlueprintId = x.ExamBlueprintId,
                ExamBlueprintCode = x.ExamBlueprint.Code,
                ExamBlueprintName = x.ExamBlueprint.Name,
                QuestionCategoryId = x.QuestionCategoryId,
                QuestionCategoryCode = x.QuestionCategory.Code,
                QuestionCategoryName = x.QuestionCategory.Name,
                EasyQuestions = x.EasyQuestions,
                MediumQuestions = x.MediumQuestions,
                HardQuestions = x.HardQuestions
            }).ToList()
        };
    }
}
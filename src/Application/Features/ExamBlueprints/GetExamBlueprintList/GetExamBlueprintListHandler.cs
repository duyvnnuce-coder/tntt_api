using Domain.Interfaces;

namespace Application.Features.ExamBlueprints.GetExamBlueprintList;

public class GetExamBlueprintListHandler
{
    private readonly IExamBlueprintRepository _repository;

    public GetExamBlueprintListHandler(
        IExamBlueprintRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetExamBlueprintListResult> Handle(
        GetExamBlueprintListRequest request)
    {
        var errors =
            GetExamBlueprintListValidator.Validate(request);

        if (errors.Any())
        {
            return new GetExamBlueprintListResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var data = await _repository.GetListAsync();

        if (!string.IsNullOrWhiteSpace(request.Keyword))
        {
            var keyword = request.Keyword.Trim().ToLower();

            data = data.Where(x =>
                    x.Code.ToLower().Contains(keyword)
                    || x.Name.ToLower().Contains(keyword)
                    || x.CatechismGrade.Code.ToLower().Contains(keyword)
                    || x.CatechismGrade.Name.ToLower().Contains(keyword))
                .ToList();
        }

        if (request.CatechismGradeId.HasValue)
        {
            data = data.Where(x =>
                    x.CatechismGradeId == request.CatechismGradeId.Value)
                .ToList();
        }

        if (request.IsActive.HasValue)
        {
            data = data.Where(x =>
                    x.IsActive == request.IsActive.Value)
                .ToList();
        }

        return new GetExamBlueprintListResult
        {
            Success = true,
            Message = "Success.",
            Data = data.Select(x => new GetExamBlueprintListResponse
            {
                Id = x.Id,
                CatechismGradeId = x.CatechismGradeId,
                CatechismGradeCode = x.CatechismGrade.Code,
                CatechismGradeName = x.CatechismGrade.Name,
                Code = x.Code,
                Name = x.Name,
                TotalQuestions = x.TotalQuestions,
                DurationMinutes = x.DurationMinutes,
                IsActive = x.IsActive
            }).ToList()
        };
    }
}
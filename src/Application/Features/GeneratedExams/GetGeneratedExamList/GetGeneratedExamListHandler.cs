using Domain.Interfaces;

namespace Application.Features.GeneratedExams.GetGeneratedExamList;

public class GetGeneratedExamListHandler
{
    private readonly IGeneratedExamRepository _repository;

    public GetGeneratedExamListHandler(
        IGeneratedExamRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetGeneratedExamListResult> Handle(
        GetGeneratedExamListRequest request)
    {
        var errors =
            GetGeneratedExamListValidator.Validate(request);

        if (errors.Any())
        {
            return new GetGeneratedExamListResult
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
                    || x.ExamBlueprint.Code.ToLower().Contains(keyword))
                .ToList();
        }

        if (request.ExamBlueprintId.HasValue)
        {
            data = data.Where(x =>
                    x.ExamBlueprintId == request.ExamBlueprintId.Value)
                .ToList();
        }

        if (request.IsPublished.HasValue)
        {
            data = data.Where(x =>
                    x.IsPublished == request.IsPublished.Value)
                .ToList();
        }

        return new GetGeneratedExamListResult
        {
            Success = true,
            Message = "Success.",
            Data = data.Select(x => new GetGeneratedExamListResponse
            {
                Id = x.Id,
                ExamBlueprintId = x.ExamBlueprintId,
                ExamBlueprintCode = x.ExamBlueprint.Code,
                Code = x.Code,
                Name = x.Name,
                GeneratedAt = x.GeneratedAt,
                IsPublished = x.IsPublished
            }).ToList()
        };
    }
}
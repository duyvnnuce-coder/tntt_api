using Domain.Interfaces;

namespace Application.Features.Exams.GetExamList;

public class GetExamListHandler
{
    private readonly IExamRepository _repository;

    public GetExamListHandler(
        IExamRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetExamListResult> Handle(
        GetExamListRequest request)
    {
        var errors =
            GetExamListValidator.Validate(request);

        if (errors.Any())
        {
            return new GetExamListResult
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
                    || x.Assignment.Class.Code.ToLower().Contains(keyword))
                .ToList();
        }

        if (request.AssignmentId.HasValue)
        {
            data = data.Where(x =>
                    x.AssignmentId == request.AssignmentId.Value)
                .ToList();
        }

        if (request.IsPublished.HasValue)
        {
            data = data.Where(x =>
                    x.IsPublished == request.IsPublished.Value)
                .ToList();
        }

        return new GetExamListResult
        {
            Success = true,
            Message = "Success.",
            Data = data.Select(x => new GetExamListResponse
            {
                Id = x.Id,
                AssignmentId = x.AssignmentId,
                AssignmentCode = x.Assignment.Class.Code,
                Code = x.Code,
                Name = x.Name,
                ExamDate = x.ExamDate,
                MaxScore = x.MaxScore,
                IsPublished = x.IsPublished
            }).ToList()
        };
    }
}
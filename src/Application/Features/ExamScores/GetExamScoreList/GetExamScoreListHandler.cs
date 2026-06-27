using Domain.Interfaces;

namespace Application.Features.ExamScores.GetExamScoreList;

public class GetExamScoreListHandler
{
    private readonly IExamScoreRepository _repository;

    public GetExamScoreListHandler(
        IExamScoreRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetExamScoreListResult> Handle(
        GetExamScoreListRequest request)
    {
        var errors =
            GetExamScoreListValidator.Validate(request);

        if (errors.Any())
        {
            return new GetExamScoreListResult
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
                    x.Exam.Code.ToLower().Contains(keyword)
                    || x.Student.Code.ToLower().Contains(keyword)
                    || x.Student.FullName.ToLower().Contains(keyword))
                .ToList();
        }

        if (request.ExamId.HasValue)
        {
            data = data.Where(x =>
                x.ExamId == request.ExamId.Value).ToList();
        }

        if (request.StudentId.HasValue)
        {
            data = data.Where(x =>
                x.StudentId == request.StudentId.Value).ToList();
        }

        return new GetExamScoreListResult
        {
            Success = true,
            Message = "Success.",
            Data = data.Select(x => new GetExamScoreListResponse
            {
                Id = x.Id,
                ExamId = x.ExamId,
                ExamCode = x.Exam.Code,
                StudentId = x.StudentId,
                StudentCode = x.Student.Code,
                StudentName = x.Student.FullName,
                Score = x.Score,
                Note = x.Note
            }).ToList()
        };
    }
}
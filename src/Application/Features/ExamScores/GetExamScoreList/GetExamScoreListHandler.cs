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
        var scores = await _repository.GetListAsync();

        return new GetExamScoreListResult
        {
            Success = true,
            Message = "Lấy danh sách điểm thi thành công.",
            Data = scores.Select(x => new GetExamScoreListResponse
            {
                Id = x.Id,
                ExamId = x.ExamId,
                ExamName = x.Exam.Name,
                StudentId = x.StudentId,
                StudentName = x.Student.FullName,
                Score = x.Score,
                Note = x.Note
            }).ToList()
        };
    }
}
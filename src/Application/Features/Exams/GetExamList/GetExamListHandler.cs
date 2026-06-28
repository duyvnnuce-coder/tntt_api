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
        var exams = await _repository.GetListAsync();

        return new GetExamListResult
        {
            Success = true,
            Message = "Lấy danh sách kỳ thi thành công.",
            Data = exams.Select(x => new GetExamListResponse
            {
                Id = x.Id,
                AssignmentId = x.AssignmentId,
                AssignmentName = x.Assignment.CatechismClass.Name,
                Code = x.Code,
                Name = x.Name,
                ExamDate = x.ExamDate,
                MaxScore = x.MaxScore,
                IsPublished = x.IsPublished
            }).ToList()
        };
    }
}
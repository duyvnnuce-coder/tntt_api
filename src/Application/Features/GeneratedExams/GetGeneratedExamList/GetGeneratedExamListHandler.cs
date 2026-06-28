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
        var entities = await _repository.GetListAsync();

        return new GetGeneratedExamListResult
        {
            Success = true,
            Message = "Lấy danh sách đề thi thành công.",
            Data = entities.Select(x => new GetGeneratedExamListResponse
            {
                Id = x.Id,
                ExamBlueprintId = x.ExamBlueprintId,
                ExamBlueprintName = x.ExamBlueprint.Name,
                Code = x.Code,
                Name = x.Name,
                GeneratedAt = x.GeneratedAt,
                IsPublished = x.IsPublished
            }).ToList()
        };
    }
}
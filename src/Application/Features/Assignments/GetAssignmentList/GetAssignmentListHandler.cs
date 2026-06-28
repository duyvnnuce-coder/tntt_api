using Domain.Interfaces;

namespace Application.Features.Assignments.GetAssignmentList;

public class GetAssignmentListHandler
{
    private readonly IAssignmentRepository _repository;

    public GetAssignmentListHandler(
        IAssignmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetAssignmentListResponse>> Handle(
        GetAssignmentListRequest request)
    {
        var data = await _repository.GetListAsync();

        return data.Select(x => new GetAssignmentListResponse
        {
            Id = x.Id,
            TeacherId = x.TeacherId,
            AssistantId = x.AssistantId,
            CatechismClassId = x.CatechismClassId,
            SemesterId = x.SemesterId,
            IsMainTeacher = x.IsMainTeacher,
            StartDate = x.StartDate,
            EndDate = x.EndDate,
            Note = x.Note
        }).ToList();
    }
}
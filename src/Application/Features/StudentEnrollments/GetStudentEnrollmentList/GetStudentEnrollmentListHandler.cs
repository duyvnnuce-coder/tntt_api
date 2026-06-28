using Domain.Interfaces;

namespace Application.Features.StudentEnrollments.GetStudentEnrollmentList;

public class GetStudentEnrollmentListHandler
{
    private readonly IStudentEnrollmentRepository _repository;

    public GetStudentEnrollmentListHandler(
        IStudentEnrollmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetStudentEnrollmentListResponse>> Handle(
        GetStudentEnrollmentListRequest request)
    {
        var data = await _repository.GetListAsync();

        return data.Select(x => new GetStudentEnrollmentListResponse
        {
            Id = x.Id,
            StudentId = x.StudentId,
            CatechismClassId = x.CatechismClassId,
            JoinDate = x.JoinDate,
            LeaveDate = x.LeaveDate,
            IsCurrent = x.IsCurrent,
            Note = x.Note
        }).ToList();
    }
}
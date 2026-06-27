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

    public async Task<GetStudentEnrollmentListResult> Handle(
        GetStudentEnrollmentListRequest request)
    {
        var errors =
            GetStudentEnrollmentListValidator.Validate(request);

        if (errors.Any())
        {
            return new GetStudentEnrollmentListResult
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
                    x.Student.Code.ToLower().Contains(keyword)
                    || x.Student.FullName.ToLower().Contains(keyword)
                    || x.Student.ChristianName.ToLower().Contains(keyword)
                    || x.CatechismClass.Code.ToLower().Contains(keyword)
                    || x.CatechismClass.Name.ToLower().Contains(keyword))
                .ToList();
        }

        if (request.IsCurrent.HasValue)
        {
            data = data.Where(x =>
                    x.IsCurrent == request.IsCurrent.Value)
                .ToList();
        }

        return new GetStudentEnrollmentListResult
        {
            Success = true,
            Message = "Success.",
            Data = data.Select(x => new GetStudentEnrollmentListResponse
            {
                Id = x.Id,
                StudentId = x.StudentId,
                StudentCode = x.Student.Code,
                ChristianName = x.Student.ChristianName,
                FullName = x.Student.FullName,
                CatechismClassId = x.CatechismClassId,
                CatechismClassCode = x.CatechismClass.Code,
                CatechismClassName = x.CatechismClass.Name,
                JoinDate = x.JoinDate,
                LeaveDate = x.LeaveDate,
                IsCurrent = x.IsCurrent,
                Note = x.Note
            }).ToList()
        };
    }
}
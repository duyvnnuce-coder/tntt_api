using Domain.Interfaces;

namespace Application.Features.Teachers.GetTeacherList;

public class GetTeacherListHandler
{
    private readonly ITeacherRepository _teacherRepository;

    public GetTeacherListHandler(
        ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public async Task<GetTeacherListResult> Handle()
    {
        var teachers = await _teacherRepository.GetListAsync();

        return new GetTeacherListResult
        {
            Success = true,
            Message = "Lấy danh sách giáo lý viên thành công.",
            Data = teachers.Select(x => new GetTeacherListResponse
            {
                Id = x.Id,
                Code = x.Code,
                ChristianName = x.ChristianName,
                FullName = x.FullName,
                Gender = x.Gender,
                Phone = x.Phone,
                IsActive = x.IsActive
            }).ToList()
        };
    }
}
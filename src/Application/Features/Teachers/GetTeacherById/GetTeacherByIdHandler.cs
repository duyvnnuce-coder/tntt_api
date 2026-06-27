using Domain.Interfaces;

namespace Application.Features.Teachers.GetTeacherById;

public class GetTeacherByIdHandler
{
    private readonly ITeacherRepository _teacherRepository;

    public GetTeacherByIdHandler(
        ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public async Task<GetTeacherByIdResult> Handle(
        GetTeacherByIdRequest request)
    {
        var teacher = await _teacherRepository.GetByIdAsync(request.Id);

        if (teacher is null)
        {
            return new GetTeacherByIdResult
            {
                Success = false,
                Message = "Không tìm thấy giáo lý viên."
            };
        }

        return new GetTeacherByIdResult
        {
            Success = true,
            Message = "Lấy thông tin giáo lý viên thành công.",
            Data = new GetTeacherByIdResponse
            {
                Id = teacher.Id,
                ParishId = teacher.ParishId,
                Code = teacher.Code,
                ChristianName = teacher.ChristianName,
                FullName = teacher.FullName,
                DateOfBirth = teacher.DateOfBirth,
                Gender = teacher.Gender,
                Phone = teacher.Phone,
                Email = teacher.Email,
                Address = teacher.Address,
                JoinDate = teacher.JoinDate,
                IsActive = teacher.IsActive
            }
        };
    }
}
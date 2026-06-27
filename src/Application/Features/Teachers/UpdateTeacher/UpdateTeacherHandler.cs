using Domain.Interfaces;

namespace Application.Features.Teachers.UpdateTeacher;

public class UpdateTeacherHandler
{
    private readonly ITeacherRepository _teacherRepository;

    public UpdateTeacherHandler(
        ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public async Task<UpdateTeacherResult> Handle(
        UpdateTeacherRequest request)
    {
        var teacher = await _teacherRepository.GetByIdAsync(request.Id);

        if (teacher is null)
        {
            return new UpdateTeacherResult
            {
                Success = false,
                Message = "Không tìm thấy giáo lý viên."
            };
        }

        teacher.ChristianName = request.ChristianName;
        teacher.FullName = request.FullName;
        teacher.DateOfBirth = request.DateOfBirth;
        teacher.Gender = request.Gender;
        teacher.Phone = request.Phone;
        teacher.Email = request.Email;
        teacher.Address = request.Address;
        teacher.JoinDate = request.JoinDate;
        teacher.IsActive = request.IsActive;

        await _teacherRepository.UpdateAsync(teacher);

        return new UpdateTeacherResult
        {
            Success = true,
            Message = "Cập nhật giáo lý viên thành công."
        };
    }
}
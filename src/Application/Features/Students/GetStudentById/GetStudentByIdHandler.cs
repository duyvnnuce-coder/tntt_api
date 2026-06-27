using Domain.Interfaces;

namespace Application.Features.Students.GetStudentById;

public class GetStudentByIdHandler
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentByIdHandler(
        IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<GetStudentByIdResult> Handle(
        GetStudentByIdRequest request)
    {
        var student = await _studentRepository
            .GetByIdAsync(request.Id);

        if (student is null)
        {
            return new GetStudentByIdResult
            {
                Success = false,
                Message = "Không tìm thấy học sinh."
            };
        }

        return new GetStudentByIdResult
        {
            Success = true,
            Message = "Lấy thông tin học sinh thành công.",
            Data = new GetStudentByIdResponse
            {
                Id = student.Id,
                Code = student.Code,
                ChristianName = student.ChristianName,
                FullName = student.FullName,
                Gender = student.Gender,
                DateOfBirth = student.DateOfBirth,
                Phone = student.Phone,
                Email = student.Email,
                Address = student.Address,
                FatherName = student.FatherName,
                MotherName = student.MotherName,
                ParentPhone = student.ParentPhone,
                JoinDate = student.JoinDate,
                ParishId = student.ParishId,
                ParishName = student.Parish.Name
            }
        };
    }
}
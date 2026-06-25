using Application.Common.Enums;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;

namespace Application.Features.Students.CreateStudent;

public class CreateStudentHandler
{
    private readonly IStudentRepository _studentRepository;
    private readonly IParishRepository _parishRepository;
    private readonly ICatechismClassRepository _classRepository;
    private readonly ICodeGenerator _codeGenerator;

    public CreateStudentHandler(
        IStudentRepository studentRepository,
        IParishRepository parishRepository,
        ICatechismClassRepository classRepository,
        ICodeGenerator codeGenerator)
    {
        _studentRepository = studentRepository;
        _parishRepository = parishRepository;
        _classRepository = classRepository;
        _codeGenerator = codeGenerator;
    }

    public async Task<CreateStudentResult> Handle(CreateStudentRequest request)
    {
        if (!await _parishRepository.ExistsAsync(request.ParishId))
        {
            return new CreateStudentResult
            {
                Success = false,
                Message = "Giáo xứ không tồn tại."
            };
        }

        if (!await _classRepository.ExistsAsync(request.CatechismClassId))
        {
            return new CreateStudentResult
            {
                Success = false,
                Message = "Lớp giáo lý không tồn tại."
            };
        }

        var code = await _codeGenerator.GenerateAsync(CodeType.Student);

        var student = new Student
        {
            ParishId = request.ParishId,
            Code = code,
            ChristianName = request.ChristianName,
            FullName = request.FullName,
            Gender = request.Gender,
            DateOfBirth = request.DateOfBirth,
            Phone = request.Phone,
            Email = request.Email,
            Address = request.Address,
            FatherName = request.FatherName,
            MotherName = request.MotherName,
            ParentPhone = request.ParentPhone,
            JoinDate = request.JoinDate
        };

        var enrollment = new StudentEnrollment
        {
            Student = student,
            CatechismClassId = request.CatechismClassId,
            JoinDate = request.JoinDate ?? DateOnly.FromDateTime(DateTime.Today),
            IsCurrent = true
        };

        var studentCard = new StudentCard
        {
            Student = student,
            Token = Guid.NewGuid().ToString("N"),
            IssuedDate = DateOnly.FromDateTime(DateTime.Today),
            Status = StudentCardStatus.Active,
            PrintCount = 0
        };

        await _studentRepository.AddAsync(
            student,
            enrollment,
            studentCard);

        return new CreateStudentResult
        {
            Success = true,
            Message = "Tạo học sinh thành công.",
            Data = new CreateStudentResponse
            {
                Id = student.Id,
                Code = student.Code,
                FullName = student.FullName
            }
        };
    }
}
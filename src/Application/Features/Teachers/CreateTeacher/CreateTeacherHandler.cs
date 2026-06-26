using Application.Common.Enums;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Features.Teachers.CreateTeacher;

public class CreateTeacherHandler
{
    private readonly ITeacherRepository _teacherRepository;
    private readonly IParishRepository _parishRepository;
    private readonly ICodeGenerator _codeGenerator;

    public CreateTeacherHandler(
        ITeacherRepository teacherRepository,
        IParishRepository parishRepository,
        ICodeGenerator codeGenerator)
    {
        _teacherRepository = teacherRepository;
        _parishRepository = parishRepository;
        _codeGenerator = codeGenerator;
    }

    public async Task<CreateTeacherResult> Handle(
        CreateTeacherRequest request,
        CancellationToken cancellationToken = default)
    {
        if (!await _parishRepository.ExistsAsync(request.ParishId))
        {
            return new CreateTeacherResult
            {
                Success = false,
                Message = "Giáo xứ không tồn tại."
            };
        }

        var code = await _codeGenerator.GenerateAsync(
            CodeType.Teacher,
            request.ParishId,
            cancellationToken);

        var teacher = new Teacher
        {
            ParishId = request.ParishId,
            Code = code,
            ChristianName = request.ChristianName ?? string.Empty,
            FullName = request.FullName,
            DateOfBirth = request.DateOfBirth,
            Phone = request.Phone,
            Email = request.Email,
            Address = request.Address,
            JoinDate = request.JoinDate
        };

        await _teacherRepository.AddAsync(teacher);

        return new CreateTeacherResult
        {
            Success = true,
            Message = "Tạo giáo lý viên thành công.",
            Data = new CreateTeacherResponse
            {
                Id = teacher.Id,
                Code = teacher.Code,
                FullName = teacher.FullName
            }
        };
    }
}
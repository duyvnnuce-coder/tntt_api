using Application.Common.Enums;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Features.Semesters.CreateSemester;

public class CreateSemesterHandler
{
    private readonly ISemesterRepository _repository;
    private readonly IAcademicYearRepository _academicYearRepository;
    private readonly ICodeGenerator _codeGenerator;

    public CreateSemesterHandler(
        ISemesterRepository repository,
        IAcademicYearRepository academicYearRepository,
        ICodeGenerator codeGenerator)
    {
        _repository = repository;
        _academicYearRepository = academicYearRepository;
        _codeGenerator = codeGenerator;
    }

    public async Task<CreateSemesterResult> Handle(CreateSemesterRequest request)
    {
        var errors = CreateSemesterValidator.Validate(request);

        if (errors.Any())
        {
            return new CreateSemesterResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        if (!await _academicYearRepository.ExistsAsync(request.AcademicYearId))
        {
            return new CreateSemesterResult
            {
                Success = false,
                Message = "Năm học không tồn tại."
            };
        }

        if (request.IsCurrent &&
            await _repository.ExistsCurrentAsync(request.AcademicYearId))
        {
            return new CreateSemesterResult
            {
                Success = false,
                Message = "Đã tồn tại học kỳ hiện hành."
            };
        }

        var academicYear =
            await _academicYearRepository.GetByIdAsync(request.AcademicYearId);

        var code = await _codeGenerator.GenerateAsync(
            CodeType.Semester,
            academicYear!.ParishId,
            CancellationToken.None);

        var semester = new Semester
        {
            AcademicYearId = request.AcademicYearId,
            Code = code,
            Name = request.Name,
            SemesterOrder = request.SemesterOrder,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            IsCurrent = request.IsCurrent
        };

        await _repository.AddAsync(semester);

        return new CreateSemesterResult
        {
            Success = true,
            Message = "Tạo học kỳ thành công.",
            Data = new CreateSemesterResponse
            {
                Id = semester.Id,
                Code = semester.Code,
                Name = semester.Name
            }
        };
    }
}
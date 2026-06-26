using Application.Common.Enums;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Features.AcademicYears.CreateAcademicYear;

public class CreateAcademicYearHandler
{
    private readonly IAcademicYearRepository _repository;
    private readonly IParishRepository _parishRepository;
    private readonly ICodeGenerator _codeGenerator;

    public CreateAcademicYearHandler(
        IAcademicYearRepository repository,
        IParishRepository parishRepository,
        ICodeGenerator codeGenerator)
    {
        _repository = repository;
        _parishRepository = parishRepository;
        _codeGenerator = codeGenerator;
    }

    public async Task<CreateAcademicYearResult> Handle(
        CreateAcademicYearRequest request)
    {
        var errors = CreateAcademicYearValidator.Validate(request);

        if (errors.Any())
        {
            return new CreateAcademicYearResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        if (!await _parishRepository.ExistsAsync(request.ParishId))
        {
            return new CreateAcademicYearResult
            {
                Success = false,
                Message = "Giáo xứ không tồn tại."
            };
        }

        if (request.IsCurrent &&
            await _repository.ExistsCurrentAsync(request.ParishId))
        {
            return new CreateAcademicYearResult
            {
                Success = false,
                Message = "Đã tồn tại năm học hiện hành."
            };
        }

        var code = await _codeGenerator.GenerateAsync(
            CodeType.AcademicYear,
            request.ParishId,
            CancellationToken.None);

        var academicYear = new AcademicYear
        {
            ParishId = request.ParishId,
            Code = code,
            Name = request.Name,
            DisplayOrder = request.DisplayOrder,
            IsCurrent = request.IsCurrent
        };

        await _repository.AddAsync(academicYear);

        return new CreateAcademicYearResult
        {
            Success = true,
            Message = "Tạo năm học thành công.",
            Data = new CreateAcademicYearResponse
            {
                Id = academicYear.Id,
                Code = academicYear.Code,
                Name = academicYear.Name
            }
        };
    }
}
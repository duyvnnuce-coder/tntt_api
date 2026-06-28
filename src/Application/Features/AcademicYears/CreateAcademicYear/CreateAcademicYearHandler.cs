using Domain.Entities;
using Domain.Interfaces;
using Application.Common.Interfaces;
using Domain.Enums;
using Application.Common.Enums;


namespace Application.Features.AcademicYears.CreateAcademicYear;

public class CreateAcademicYearHandler
{
    private readonly IAcademicYearRepository _repository;
    private readonly ICodeGenerator _codeGenerator;

    public CreateAcademicYearHandler(
        IAcademicYearRepository repository,
        ICodeGenerator codeGenerator)
    {
        _repository = repository;
        _codeGenerator = codeGenerator;
    }

    public async Task<CreateAcademicYearResult> Handle(
        CreateAcademicYearRequest request)
    {
        var entity = new AcademicYear
        {
            ParishId = request.ParishId,
            Code = await _codeGenerator.GenerateAsync(
                CodeType.AcademicYear,
                request.ParishId),
            Name = request.Name,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            IsCurrent = request.IsCurrent,
            DisplayOrder = request.DisplayOrder
        };

        await _repository.AddAsync(entity);

        return new CreateAcademicYearResult
        {
            Success = true,
            Message = "Tạo năm học thành công.",
            Data = new CreateAcademicYearResponse
            {
                Id = entity.Id,
                Code = entity.Code,
                Name = entity.Name
            }
        };
    }
}
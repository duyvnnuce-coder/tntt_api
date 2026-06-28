using Application.Common.Enums;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Features.CatechismClasses.CreateCatechismClass;

public class CreateCatechismClassHandler
{
    private readonly ICatechismClassRepository _repository;
    private readonly IParishRepository _parishRepository;
    private readonly IAcademicYearRepository _academicYearRepository;
    private readonly ICatechismGradeRepository _catechismGradeRepository;
    private readonly ICodeGenerator _codeGenerator;

    public CreateCatechismClassHandler(
        ICatechismClassRepository repository,
        IParishRepository parishRepository,
        IAcademicYearRepository academicYearRepository,
        ICatechismGradeRepository catechismGradeRepository,
        ICodeGenerator codeGenerator)
    {
        _repository = repository;
        _parishRepository = parishRepository;
        _academicYearRepository = academicYearRepository;
        _catechismGradeRepository = catechismGradeRepository;
        _codeGenerator = codeGenerator;
    }

    public async Task<CreateCatechismClassResult> Handle(
        CreateCatechismClassRequest request)
    {
        var errors = CreateCatechismClassValidator.Validate(request);

        if (errors.Any())
        {
            return new CreateCatechismClassResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        if (!await _parishRepository.ExistsAsync(request.ParishId))
        {
            return new CreateCatechismClassResult
            {
                Success = false,
                Message = "Giáo xứ không tồn tại."
            };
        }

        if (!await _academicYearRepository.ExistsAsync(request.AcademicYearId))
        {
            return new CreateCatechismClassResult
            {
                Success = false,
                Message = "Năm học không tồn tại."
            };
        }

        if (!await _catechismGradeRepository.ExistsAsync(request.CatechismGradeId))
        {
            return new CreateCatechismClassResult
            {
                Success = false,
                Message = "Khối giáo lý không tồn tại."
            };
        }

        var catechismClass = new CatechismClass
        {
            ParishId = request.ParishId,
            AcademicYearId = request.AcademicYearId,
            CatechismGradeId = request.CatechismGradeId,

            Code = await _codeGenerator.GenerateAsync(
                CodeType.CatechismClass,
                request.ParishId),

            Name = request.Name,
            DisplayOrder = request.DisplayOrder,
            MaxStudents = request.MaxStudents,
            IsActive = request.IsActive
        };

        await _repository.AddAsync(catechismClass);

        return new CreateCatechismClassResult
        {
            Success = true,
            Message = "Tạo lớp giáo lý thành công.",
            Data = new CreateCatechismClassResponse
            {
                Id = catechismClass.Id,
                Code = catechismClass.Code,
                Name = catechismClass.Name
            }
        };
    }
}
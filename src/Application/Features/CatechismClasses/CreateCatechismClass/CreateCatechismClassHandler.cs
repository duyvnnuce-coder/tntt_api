using Domain.Entities;
using Domain.Interfaces;

namespace Application.Features.CatechismClasses.CreateCatechismClass;

public class CreateCatechismClassHandler
{
    private readonly ICatechismClassRepository _repository;

    public CreateCatechismClassHandler(
        ICatechismClassRepository repository)
    {
        _repository = repository;
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

        var catechismClass = new CatechismClass
        {
            ParishId = request.ParishId,
            AcademicYearId = request.AcademicYearId,
            CatechismGradeId = request.CatechismGradeId,
            Code = request.Code,
            Name = request.Name,
            DisplayOrder = request.DisplayOrder,
            MaxStudents = request.MaxStudents,
            IsActive = true
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
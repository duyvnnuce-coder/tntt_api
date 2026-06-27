using Domain.Entities;
using Domain.Interfaces;

namespace Application.Features.CatechismGrades.CreateCatechismGrade;

public class CreateCatechismGradeHandler
{
    private readonly ICatechismGradeRepository _repository;
    private readonly IParishRepository _parishRepository;

    public CreateCatechismGradeHandler(
        ICatechismGradeRepository repository,
        IParishRepository parishRepository)
    {
        _repository = repository;
        _parishRepository = parishRepository;
    }

    public async Task<CreateCatechismGradeResult> Handle(
        CreateCatechismGradeRequest request)
    {
        var errors = CreateCatechismGradeValidator.Validate(request);

        if (errors.Any())
        {
            return new CreateCatechismGradeResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        if (!await _parishRepository.ExistsAsync(request.ParishId))
        {
            return new CreateCatechismGradeResult
            {
                Success = false,
                Message = "Giáo xứ không tồn tại."
            };
        }

        var grade = new CatechismGrade
        {
            ParishId = request.ParishId,
            Code = request.Code,
            Name = request.Name,
            DisplayOrder = request.DisplayOrder,
            IsActive = request.IsActive
        };

        await _repository.AddAsync(grade);

        return new CreateCatechismGradeResult
        {
            Success = true,
            Message = "Tạo khối giáo lý thành công.",
            Data = new CreateCatechismGradeResponse
            {
                Id = grade.Id,
                Code = grade.Code,
                Name = grade.Name
            }
        };
    }
}
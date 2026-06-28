using Domain.Interfaces;

namespace Application.Features.CatechismGrades.GetCatechismGradeById;

public class GetCatechismGradeByIdHandler
{
    private readonly ICatechismGradeRepository _repository;

    public GetCatechismGradeByIdHandler(
        ICatechismGradeRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetCatechismGradeByIdResult> Handle(
        GetCatechismGradeByIdRequest request)
    {
        var grade = await _repository.GetByIdAsync(request.Id);

        if (grade is null)
        {
            return new GetCatechismGradeByIdResult
            {
                Success = false,
                Message = "Không tìm thấy khối giáo lý."
            };
        }

        return new GetCatechismGradeByIdResult
        {
            Success = true,
            Message = "Thành công.",
            Data = new GetCatechismGradeByIdResponse
            {
                Id = grade.Id,
                ParishId = grade.ParishId,
                Code = grade.Code,
                Name = grade.Name,
                DisplayOrder = grade.DisplayOrder,
                IsActive = grade.IsActive
            }
        };
    }
}
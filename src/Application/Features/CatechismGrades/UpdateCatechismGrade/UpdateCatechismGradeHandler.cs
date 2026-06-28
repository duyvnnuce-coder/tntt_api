using Domain.Interfaces;

namespace Application.Features.CatechismGrades.UpdateCatechismGrade;

public class UpdateCatechismGradeHandler
{
    private readonly ICatechismGradeRepository _repository;

    public UpdateCatechismGradeHandler(
        ICatechismGradeRepository repository)
    {
        _repository = repository;
    }

    public async Task<UpdateCatechismGradeResult> Handle(
        UpdateCatechismGradeRequest request)
    {
        var grade = await _repository.GetByIdAsync(request.Id);

        if (grade is null)
        {
            return new UpdateCatechismGradeResult
            {
                Success = false,
                Message = "Không tìm thấy khối giáo lý."
            };
        }

        grade.Name = request.Name;
        grade.DisplayOrder = request.DisplayOrder;
        grade.IsActive = request.IsActive;

        await _repository.UpdateAsync(grade);

        return new UpdateCatechismGradeResult
        {
            Success = true,
            Message = "Cập nhật khối giáo lý thành công."
        };
    }
}
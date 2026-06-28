using Domain.Interfaces;

namespace Application.Features.CatechismGrades.DeleteCatechismGrade;

public class DeleteCatechismGradeHandler
{
    private readonly ICatechismGradeRepository _repository;

    public DeleteCatechismGradeHandler(
        ICatechismGradeRepository repository)
    {
        _repository = repository;
    }

    public async Task<DeleteCatechismGradeResult> Handle(
        DeleteCatechismGradeRequest request)
    {
        var grade = await _repository.GetByIdAsync(request.Id);

        if (grade is null)
        {
            return new DeleteCatechismGradeResult
            {
                Success = false,
                Message = "Không tìm thấy khối giáo lý."
            };
        }

        await _repository.DeleteAsync(grade);

        return new DeleteCatechismGradeResult
        {
            Success = true,
            Message = "Xóa khối giáo lý thành công."
        };
    }
}
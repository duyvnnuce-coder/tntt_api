using Domain.Interfaces;

namespace Application.Features.CatechismClasses.UpdateCatechismClass;

public class UpdateCatechismClassHandler
{
    private readonly ICatechismClassRepository _repository;

    public UpdateCatechismClassHandler(
        ICatechismClassRepository repository)
    {
        _repository = repository;
    }

    public async Task<UpdateCatechismClassResult> Handle(
        UpdateCatechismClassRequest request)
    {
        var catechismClass = await _repository.GetByIdAsync(request.Id);

        if (catechismClass is null)
        {
            return new UpdateCatechismClassResult
            {
                Success = false,
                Message = "Không tìm thấy lớp giáo lý."
            };
        }

        catechismClass.Name = request.Name;
        catechismClass.DisplayOrder = request.DisplayOrder;
        catechismClass.MaxStudents = request.MaxStudents;
        catechismClass.IsActive = request.IsActive;

        await _repository.UpdateAsync(catechismClass);

        return new UpdateCatechismClassResult
        {
            Success = true,
            Message = "Cập nhật lớp giáo lý thành công."
        };
    }
}
using Domain.Interfaces;

namespace Application.Features.CatechismClasses.DeleteCatechismClass;

public class DeleteCatechismClassHandler
{
    private readonly ICatechismClassRepository _repository;

    public DeleteCatechismClassHandler(
        ICatechismClassRepository repository)
    {
        _repository = repository;
    }

    public async Task<DeleteCatechismClassResult> Handle(
        DeleteCatechismClassRequest request)
    {
        var catechismClass = await _repository.GetByIdAsync(request.Id);

        if (catechismClass is null)
        {
            return new DeleteCatechismClassResult
            {
                Success = false,
                Message = "Không tìm thấy lớp giáo lý."
            };
        }

        await _repository.DeleteAsync(catechismClass);

        return new DeleteCatechismClassResult
        {
            Success = true,
            Message = "Xóa lớp giáo lý thành công."
        };
    }
}
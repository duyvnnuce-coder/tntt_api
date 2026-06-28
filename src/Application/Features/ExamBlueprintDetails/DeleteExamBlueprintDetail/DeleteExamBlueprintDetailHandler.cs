using Domain.Interfaces;

namespace Application.Features.ExamBlueprintDetails.DeleteExamBlueprintDetail;

public class DeleteExamBlueprintDetailHandler
{
    private readonly IExamBlueprintDetailRepository _repository;

    public DeleteExamBlueprintDetailHandler(
        IExamBlueprintDetailRepository repository)
    {
        _repository = repository;
    }

    public async Task<DeleteExamBlueprintDetailResult> Handle(
        DeleteExamBlueprintDetailRequest request)
    {
        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity is null)
        {
            return new DeleteExamBlueprintDetailResult
            {
                Success = false,
                Message = "Không tìm thấy chi tiết ma trận đề."
            };
        }

        await _repository.DeleteAsync(entity);

        return new DeleteExamBlueprintDetailResult
        {
            Success = true,
            Message = "Xóa chi tiết ma trận đề thành công."
        };
    }
}
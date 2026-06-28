using Domain.Interfaces;

namespace Application.Features.ExamBlueprints.DeleteExamBlueprint;

public class DeleteExamBlueprintHandler
{
    private readonly IExamBlueprintRepository _repository;

    public DeleteExamBlueprintHandler(
        IExamBlueprintRepository repository)
    {
        _repository = repository;
    }

    public async Task<DeleteExamBlueprintResult> Handle(
        DeleteExamBlueprintRequest request)
    {
        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity is null)
        {
            return new DeleteExamBlueprintResult
            {
                Success = false,
                Message = "Không tìm thấy mẫu đề."
            };
        }

        await _repository.DeleteAsync(entity);

        return new DeleteExamBlueprintResult
        {
            Success = true,
            Message = "Xóa mẫu đề thành công."
        };
    }
}
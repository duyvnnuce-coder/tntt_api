using Domain.Interfaces;

namespace Application.Features.ExamBlueprintDetails.UpdateExamBlueprintDetail;

public class UpdateExamBlueprintDetailHandler
{
    private readonly IExamBlueprintDetailRepository _repository;

    public UpdateExamBlueprintDetailHandler(
        IExamBlueprintDetailRepository repository)
    {
        _repository = repository;
    }

    public async Task<UpdateExamBlueprintDetailResult> Handle(
        UpdateExamBlueprintDetailRequest request)
    {
        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity is null)
        {
            return new UpdateExamBlueprintDetailResult
            {
                Success = false,
                Message = "Không tìm thấy chi tiết ma trận đề."
            };
        }

        entity.QuestionCategoryId = request.QuestionCategoryId;
        entity.EasyQuestions = request.EasyQuestions;
        entity.MediumQuestions = request.MediumQuestions;
        entity.HardQuestions = request.HardQuestions;

        await _repository.UpdateAsync(entity);

        return new UpdateExamBlueprintDetailResult
        {
            Success = true,
            Message = "Cập nhật thành công."
        };
    }
}
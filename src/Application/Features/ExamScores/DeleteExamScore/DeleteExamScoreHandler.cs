using Domain.Interfaces;

namespace Application.Features.ExamScores.DeleteExamScore;

public class DeleteExamScoreHandler
{
    private readonly IExamScoreRepository _repository;

    public DeleteExamScoreHandler(
        IExamScoreRepository repository)
    {
        _repository = repository;
    }

    public async Task<DeleteExamScoreResult> Handle(
        DeleteExamScoreRequest request)
    {
        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity is null)
        {
            return new DeleteExamScoreResult
            {
                Success = false,
                Message = "Không tìm thấy điểm thi."
            };
        }

        await _repository.DeleteAsync(entity);

        return new DeleteExamScoreResult
        {
            Success = true,
            Message = "Xóa điểm thi thành công."
        };
    }
}
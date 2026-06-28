using Domain.Interfaces;

namespace Application.Features.ExamScores.UpdateExamScore;

public class UpdateExamScoreHandler
{
    private readonly IExamScoreRepository _repository;

    public UpdateExamScoreHandler(
        IExamScoreRepository repository)
    {
        _repository = repository;
    }

    public async Task<UpdateExamScoreResult> Handle(
        UpdateExamScoreRequest request)
    {
        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity is null)
        {
            return new UpdateExamScoreResult
            {
                Success = false,
                Message = "Không tìm thấy điểm thi."
            };
        }

        entity.ExamId = request.ExamId;
        entity.StudentId = request.StudentId;
        entity.Score = request.Score;
        entity.Note = request.Note;

        await _repository.UpdateAsync(entity);

        return new UpdateExamScoreResult
        {
            Success = true,
            Message = "Cập nhật điểm thi thành công."
        };
    }
}
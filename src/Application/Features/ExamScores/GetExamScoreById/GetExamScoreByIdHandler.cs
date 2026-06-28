using Domain.Interfaces;

namespace Application.Features.ExamScores.GetExamScoreById;

public class GetExamScoreByIdHandler
{
    private readonly IExamScoreRepository _repository;

    public GetExamScoreByIdHandler(
        IExamScoreRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetExamScoreByIdResult> Handle(
        GetExamScoreByIdRequest request)
    {
        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity is null)
        {
            return new GetExamScoreByIdResult
            {
                Success = false,
                Message = "Không tìm thấy điểm thi."
            };
        }

        return new GetExamScoreByIdResult
        {
            Success = true,
            Message = "Lấy thông tin điểm thi thành công.",
            Data = new GetExamScoreByIdResponse
            {
                Id = entity.Id,
                ExamId = entity.ExamId,
                ExamName = entity.Exam.Name,
                StudentId = entity.StudentId,
                StudentName = entity.Student.FullName,
                Score = entity.Score,
                Note = entity.Note
            }
        };
    }
}
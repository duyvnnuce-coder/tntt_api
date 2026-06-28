using Domain.Entities;
using Domain.Interfaces;

namespace Application.Features.ExamScores.CreateExamScore;

public class CreateExamScoreHandler
{
    private readonly IExamScoreRepository _repository;

    public CreateExamScoreHandler(
        IExamScoreRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateExamScoreResult> Handle(
        CreateExamScoreRequest request)
    {
        var error = CreateExamScoreValidator.Validate(request);

        if (error is not null)
        {
            return new CreateExamScoreResult
            {
                Success = false,
                Message = error
            };
        }

        var entity = new ExamScore
        {
            ExamId = request.ExamId,
            StudentId = request.StudentId,
            Score = request.Score,
            Note = request.Note
        };

        await _repository.AddAsync(entity);

        return new CreateExamScoreResult
        {
            Success = true,
            Message = "Tạo điểm thi thành công.",
            Data = new CreateExamScoreResponse
            {
                Id = entity.Id
            }
        };
    }
}
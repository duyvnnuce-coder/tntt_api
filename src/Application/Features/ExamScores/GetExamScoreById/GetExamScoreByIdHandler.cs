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
        var errors =
            GetExamScoreByIdValidator.Validate(request);

        if (errors.Any())
        {
            return new GetExamScoreByIdResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity == null)
        {
            return new GetExamScoreByIdResult
            {
                Success = false,
                Message = "Exam score not found."
            };
        }

        return new GetExamScoreByIdResult
        {
            Success = true,
            Message = "Success.",
            Data = new GetExamScoreByIdResponse
            {
                Id = entity.Id,
                ExamId = entity.ExamId,
                ExamCode = entity.Exam.Code,
                StudentId = entity.StudentId,
                StudentCode = entity.Student.Code,
                StudentName = entity.Student.FullName,
                Score = entity.Score,
                Note = entity.Note
            }
        };
    }
}
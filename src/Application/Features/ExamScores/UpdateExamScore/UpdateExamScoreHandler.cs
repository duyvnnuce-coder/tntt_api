using Domain.Interfaces;

namespace Application.Features.ExamScores.UpdateExamScore;

public class UpdateExamScoreHandler
{
    private readonly IExamScoreRepository _repository;
    private readonly IExamRepository _examRepository;
    private readonly IStudentRepository _studentRepository;

    public UpdateExamScoreHandler(
        IExamScoreRepository repository,
        IExamRepository examRepository,
        IStudentRepository studentRepository)
    {
        _repository = repository;
        _examRepository = examRepository;
        _studentRepository = studentRepository;
    }

    public async Task<UpdateExamScoreResult> Handle(
        UpdateExamScoreRequest request)
    {
        var errors = UpdateExamScoreValidator.Validate(request);

        if (errors.Any())
        {
            return new UpdateExamScoreResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity == null)
        {
            return new UpdateExamScoreResult
            {
                Success = false,
                Message = "Exam score not found."
            };
        }

        var exam = await _examRepository.GetByIdAsync(request.ExamId);

        if (exam == null)
        {
            return new UpdateExamScoreResult
            {
                Success = false,
                Message = "Exam not found."
            };
        }

        var student = await _studentRepository.GetByIdAsync(request.StudentId);

        if (student == null)
        {
            return new UpdateExamScoreResult
            {
                Success = false,
                Message = "Student not found."
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
            Message = "Exam score updated successfully.",
            Data = new UpdateExamScoreResponse
            {
                Id = entity.Id,
                ExamId = entity.ExamId,
                ExamCode = exam.Code,
                StudentId = entity.StudentId,
                StudentCode = student.Code,
                StudentName = student.FullName,
                Score = entity.Score,
                Note = entity.Note
            }
        };
    }
}
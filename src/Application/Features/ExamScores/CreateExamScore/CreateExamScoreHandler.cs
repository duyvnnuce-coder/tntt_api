using Domain.Entities;
using Domain.Interfaces;

namespace Application.Features.ExamScores.CreateExamScore;

public class CreateExamScoreHandler
{
    private readonly IExamScoreRepository _repository;
    private readonly IExamRepository _examRepository;
    private readonly IStudentRepository _studentRepository;

    public CreateExamScoreHandler(
        IExamScoreRepository repository,
        IExamRepository examRepository,
        IStudentRepository studentRepository)
    {
        _repository = repository;
        _examRepository = examRepository;
        _studentRepository = studentRepository;
    }

    public async Task<CreateExamScoreResult> Handle(
        CreateExamScoreRequest request)
    {
        var errors = CreateExamScoreValidator.Validate(request);

        if (errors.Any())
        {
            return new CreateExamScoreResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var exam = await _examRepository.GetByIdAsync(request.ExamId);

        if (exam == null)
        {
            return new CreateExamScoreResult
            {
                Success = false,
                Message = "Exam not found."
            };
        }

        var student = await _studentRepository.GetByIdAsync(request.StudentId);

        if (student == null)
        {
            return new CreateExamScoreResult
            {
                Success = false,
                Message = "Student not found."
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
            Message = "Exam score created successfully.",
            Data = new CreateExamScoreResponse
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
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Features.Exams.CreateExam;

public class CreateExamHandler
{
    private readonly IExamRepository _repository;
    private readonly IAssignmentRepository _assignmentRepository;

    public CreateExamHandler(
        IExamRepository repository,
        IAssignmentRepository assignmentRepository)
    {
        _repository = repository;
        _assignmentRepository = assignmentRepository;
    }

    public async Task<CreateExamResult> Handle(
        CreateExamRequest request)
    {
        var errors = CreateExamValidator.Validate(request);

        if (errors.Any())
        {
            return new CreateExamResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var assignment =
            await _assignmentRepository.GetByIdAsync(request.AssignmentId);

        if (assignment == null)
        {
            return new CreateExamResult
            {
                Success = false,
                Message = "Assignment not found."
            };
        }

        var entity = new Exam
        {
            AssignmentId = request.AssignmentId,
            Code = request.Code.Trim(),
            Name = request.Name.Trim(),
            ExamDate = request.ExamDate,
            MaxScore = request.MaxScore,
            IsPublished = request.IsPublished
        };

        await _repository.AddAsync(entity);

        return new CreateExamResult
        {
            Success = true,
            Message = "Exam created successfully.",
            Data = new CreateExamResponse
            {
                Id = entity.Id,
                AssignmentId = entity.AssignmentId,
                AssignmentCode = assignment.Class.Code,
                Code = entity.Code,
                Name = entity.Name,
                ExamDate = entity.ExamDate,
                MaxScore = entity.MaxScore,
                IsPublished = entity.IsPublished
            }
        };
    }
}
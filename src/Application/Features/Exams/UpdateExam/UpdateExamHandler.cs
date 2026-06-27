using Domain.Interfaces;

namespace Application.Features.Exams.UpdateExam;

public class UpdateExamHandler
{
    private readonly IExamRepository _repository;
    private readonly IAssignmentRepository _assignmentRepository;

    public UpdateExamHandler(
        IExamRepository repository,
        IAssignmentRepository assignmentRepository)
    {
        _repository = repository;
        _assignmentRepository = assignmentRepository;
    }

    public async Task<UpdateExamResult> Handle(
        UpdateExamRequest request)
    {
        var errors = UpdateExamValidator.Validate(request);

        if (errors.Any())
        {
            return new UpdateExamResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity == null)
        {
            return new UpdateExamResult
            {
                Success = false,
                Message = "Exam not found."
            };
        }

        var assignment =
            await _assignmentRepository.GetByIdAsync(
                request.AssignmentId);

        if (assignment == null)
        {
            return new UpdateExamResult
            {
                Success = false,
                Message = "Assignment not found."
            };
        }

        entity.AssignmentId = request.AssignmentId;
        entity.Code = request.Code.Trim();
        entity.Name = request.Name.Trim();
        entity.ExamDate = request.ExamDate;
        entity.MaxScore = request.MaxScore;
        entity.IsPublished = request.IsPublished;

        await _repository.UpdateAsync(entity);

        return new UpdateExamResult
        {
            Success = true,
            Message = "Exam updated successfully.",
            Data = new UpdateExamResponse
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
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Features.Assignments.CreateAssignment;

public class CreateAssignmentHandler
{
    private readonly IAssignmentRepository _repository;

    public CreateAssignmentHandler(
        IAssignmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateAssignmentResult> Handle(
        CreateAssignmentRequest request)
    {
        var errors = CreateAssignmentValidator.Validate(request);

        if (errors.Any())
        {
            return new CreateAssignmentResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        if (await _repository.ExistsDuplicateAsync(
            request.SemesterId,
            request.CatechismClassId,
            request.TeacherId))
        {
            return new CreateAssignmentResult
            {
                Success = false,
                Message = "Giáo viên đã được phân công cho lớp này trong học kỳ."
            };
        }

        var assignment = new Assignment
        {
            TeacherId = request.TeacherId,
            AssistantId = request.AssistantId,
            CatechismClassId = request.CatechismClassId,
            SemesterId = request.SemesterId,
            IsMainTeacher = request.IsMainTeacher,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Note = request.Note
        };

        await _repository.AddAsync(assignment);

        return new CreateAssignmentResult
        {
            Success = true,
            Message = "Tạo phân công thành công.",
            Data = new CreateAssignmentResponse
            {
                Id = assignment.Id,
                TeacherId = assignment.TeacherId,
                AssistantId = assignment.AssistantId,
                CatechismClassId = assignment.CatechismClassId,
                SemesterId = assignment.SemesterId
            }
        };
    }
}
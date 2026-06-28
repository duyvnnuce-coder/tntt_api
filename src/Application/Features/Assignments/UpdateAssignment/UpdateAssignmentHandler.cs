using Domain.Interfaces;

namespace Application.Features.Assignments.UpdateAssignment;

public class UpdateAssignmentHandler
{
    private readonly IAssignmentRepository _repository;

    public UpdateAssignmentHandler(
        IAssignmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<UpdateAssignmentResult> Handle(
        UpdateAssignmentRequest request)
    {
        var assignment = await _repository.GetByIdAsync(request.Id);

        if (assignment is null)
        {
            return new UpdateAssignmentResult
            {
                Success = false,
                Message = "Không tìm thấy phân công."
            };
        }

        assignment.TeacherId = request.TeacherId;
        assignment.AssistantId = request.AssistantId;
        assignment.CatechismClassId = request.CatechismClassId;
        assignment.SemesterId = request.SemesterId;
        assignment.IsMainTeacher = request.IsMainTeacher;
        assignment.StartDate = request.StartDate;
        assignment.EndDate = request.EndDate;
        assignment.Note = request.Note;

        await _repository.UpdateAsync(assignment);

        return new UpdateAssignmentResult
        {
            Success = true,
            Message = "Cập nhật phân công thành công."
        };
    }
}
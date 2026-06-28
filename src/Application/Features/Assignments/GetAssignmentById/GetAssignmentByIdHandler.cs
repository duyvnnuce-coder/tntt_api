using Domain.Interfaces;

namespace Application.Features.Assignments.GetAssignmentById;

public class GetAssignmentByIdHandler
{
    private readonly IAssignmentRepository _repository;

    public GetAssignmentByIdHandler(
        IAssignmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetAssignmentByIdResult> Handle(
        GetAssignmentByIdRequest request)
    {
        var assignment = await _repository.GetByIdAsync(request.Id);

        if (assignment is null)
        {
            return new GetAssignmentByIdResult
            {
                Success = false,
                Message = "Không tìm thấy phân công."
            };
        }

        return new GetAssignmentByIdResult
        {
            Success = true,
            Message = "Thành công.",
            Data = new GetAssignmentByIdResponse
            {
                Id = assignment.Id,
                TeacherId = assignment.TeacherId,
                AssistantId = assignment.AssistantId,
                CatechismClassId = assignment.CatechismClassId,
                SemesterId = assignment.SemesterId,
                IsMainTeacher = assignment.IsMainTeacher,
                StartDate = assignment.StartDate,
                EndDate = assignment.EndDate,
                Note = assignment.Note
            }
        };
    }
}
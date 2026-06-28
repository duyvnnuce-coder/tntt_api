using Domain.Interfaces;

namespace Application.Features.Assignments.DeleteAssignment;

public class DeleteAssignmentHandler
{
    private readonly IAssignmentRepository _repository;

    public DeleteAssignmentHandler(
        IAssignmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<DeleteAssignmentResult> Handle(
        DeleteAssignmentRequest request)
    {
        var assignment = await _repository.GetByIdAsync(request.Id);

        if (assignment is null)
        {
            return new DeleteAssignmentResult
            {
                Success = false,
                Message = "Không tìm thấy phân công."
            };
        }

        await _repository.DeleteAsync(assignment);

        return new DeleteAssignmentResult
        {
            Success = true,
            Message = "Xóa phân công thành công."
        };
    }
}
using Domain.Interfaces;

namespace Application.Features.StudentEnrollments.DeleteStudentEnrollment;

public class DeleteStudentEnrollmentHandler
{
    private readonly IStudentEnrollmentRepository _repository;

    public DeleteStudentEnrollmentHandler(
        IStudentEnrollmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<DeleteStudentEnrollmentResult> Handle(
        DeleteStudentEnrollmentRequest request)
    {
        var enrollment = await _repository.GetByIdAsync(request.Id);

        if (enrollment is null)
        {
            return new DeleteStudentEnrollmentResult
            {
                Success = false,
                Message = "Không tìm thấy phân lớp."
            };
        }

        await _repository.DeleteAsync(enrollment);

        return new DeleteStudentEnrollmentResult
        {
            Success = true,
            Message = "Xóa phân lớp thành công."
        };
    }
}
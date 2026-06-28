using Domain.Interfaces;

namespace Application.Features.StudentEnrollments.UpdateStudentEnrollment;

public class UpdateStudentEnrollmentHandler
{
    private readonly IStudentEnrollmentRepository _repository;

    public UpdateStudentEnrollmentHandler(
        IStudentEnrollmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<UpdateStudentEnrollmentResult> Handle(
        UpdateStudentEnrollmentRequest request)
    {
        var enrollment = await _repository.GetByIdAsync(request.Id);

        if (enrollment is null)
        {
            return new UpdateStudentEnrollmentResult
            {
                Success = false,
                Message = "Không tìm thấy phân lớp."
            };
        }

        enrollment.CatechismClassId = request.CatechismClassId;
        enrollment.JoinDate = request.JoinDate;
        enrollment.LeaveDate = request.LeaveDate;
        enrollment.IsCurrent = request.IsCurrent;
        enrollment.Note = request.Note;

        await _repository.UpdateAsync(enrollment);

        return new UpdateStudentEnrollmentResult
        {
            Success = true,
            Message = "Cập nhật phân lớp thành công."
        };
    }
}
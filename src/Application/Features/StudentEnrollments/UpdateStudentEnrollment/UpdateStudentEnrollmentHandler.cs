using Domain.Interfaces;

namespace Application.Features.StudentEnrollments.UpdateStudentEnrollment;

public class UpdateStudentEnrollmentHandler
{
    private readonly IStudentEnrollmentRepository _repository;
    private readonly ICatechismClassRepository _classRepository;

    public UpdateStudentEnrollmentHandler(
        IStudentEnrollmentRepository repository,
        ICatechismClassRepository classRepository)
    {
        _repository = repository;
        _classRepository = classRepository;
    }

    public async Task<UpdateStudentEnrollmentResult> Handle(
        UpdateStudentEnrollmentRequest request)
    {
        var errors =
            UpdateStudentEnrollmentValidator.Validate(request);

        if (errors.Any())
        {
            return new UpdateStudentEnrollmentResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var enrollment = await _repository.GetByIdAsync(request.Id);

        if (enrollment == null)
        {
            return new UpdateStudentEnrollmentResult
            {
                Success = false,
                Message = "Student enrollment not found."
            };
        }

        if (!await _classRepository.ExistsAsync(request.CatechismClassId))
        {
            return new UpdateStudentEnrollmentResult
            {
                Success = false,
                Message = "Catechism class not found."
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
            Message = "Student enrollment updated successfully.",
            Data = new UpdateStudentEnrollmentResponse
            {
                Id = enrollment.Id,
                StudentId = enrollment.StudentId,
                CatechismClassId = enrollment.CatechismClassId,
                JoinDate = enrollment.JoinDate,
                LeaveDate = enrollment.LeaveDate,
                IsCurrent = enrollment.IsCurrent,
                Note = enrollment.Note
            }
        };
    }
}
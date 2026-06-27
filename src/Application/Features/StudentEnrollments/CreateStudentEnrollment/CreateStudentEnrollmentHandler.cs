using Domain.Entities;
using Domain.Interfaces;

namespace Application.Features.StudentEnrollments.CreateStudentEnrollment;

public class CreateStudentEnrollmentHandler
{
    private readonly IStudentRepository _studentRepository;
    private readonly ICatechismClassRepository _classRepository;
    private readonly IStudentEnrollmentRepository _enrollmentRepository;

    public CreateStudentEnrollmentHandler(
        IStudentRepository studentRepository,
        ICatechismClassRepository classRepository,
        IStudentEnrollmentRepository enrollmentRepository)
    {
        _studentRepository = studentRepository;
        _classRepository = classRepository;
        _enrollmentRepository = enrollmentRepository;
    }

    public async Task<CreateStudentEnrollmentResult> Handle(
        CreateStudentEnrollmentRequest request)
    {
        var errors =
            CreateStudentEnrollmentValidator.Validate(request);

        if (errors.Any())
        {
            return new CreateStudentEnrollmentResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        if (!await _studentRepository.ExistsAsync(request.StudentId))
        {
            return new CreateStudentEnrollmentResult
            {
                Success = false,
                Message = "Student not found."
            };
        }

        if (!await _classRepository.ExistsAsync(request.CatechismClassId))
        {
            return new CreateStudentEnrollmentResult
            {
                Success = false,
                Message = "Catechism class not found."
            };
        }

        var current =
            await _enrollmentRepository.GetCurrentByStudentIdAsync(
                request.StudentId);

        if (current != null)
        {
            return new CreateStudentEnrollmentResult
            {
                Success = false,
                Message = "Student already has a current enrollment."
            };
        }

        var enrollment = new StudentEnrollment
        {
            StudentId = request.StudentId,
            CatechismClassId = request.CatechismClassId,
            JoinDate = request.JoinDate,
            IsCurrent = true,
            Note = request.Note
        };

        await _enrollmentRepository.AddAsync(enrollment);

        return new CreateStudentEnrollmentResult
        {
            Success = true,
            Message = "Student enrollment created successfully.",
            Data = new CreateStudentEnrollmentResponse
            {
                Id = enrollment.Id,
                StudentId = enrollment.StudentId,
                CatechismClassId = enrollment.CatechismClassId,
                JoinDate = enrollment.JoinDate,
                IsCurrent = enrollment.IsCurrent
            }
        };
    }
}
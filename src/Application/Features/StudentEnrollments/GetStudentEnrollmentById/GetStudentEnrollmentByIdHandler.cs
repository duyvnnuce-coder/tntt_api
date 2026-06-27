using Domain.Interfaces;

namespace Application.Features.StudentEnrollments.GetStudentEnrollmentById;

public class GetStudentEnrollmentByIdHandler
{
    private readonly IStudentEnrollmentRepository _repository;

    public GetStudentEnrollmentByIdHandler(
        IStudentEnrollmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetStudentEnrollmentByIdResult> Handle(
        GetStudentEnrollmentByIdRequest request)
    {
        var errors =
            GetStudentEnrollmentByIdValidator.Validate(request);

        if (errors.Any())
        {
            return new GetStudentEnrollmentByIdResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity == null)
        {
            return new GetStudentEnrollmentByIdResult
            {
                Success = false,
                Message = "Student enrollment not found."
            };
        }

        return new GetStudentEnrollmentByIdResult
        {
            Success = true,
            Message = "Success.",
            Data = new GetStudentEnrollmentByIdResponse
            {
                Id = entity.Id,
                StudentId = entity.StudentId,
                StudentCode = entity.Student.Code,
                ChristianName = entity.Student.ChristianName,
                FullName = entity.Student.FullName,
                CatechismClassId = entity.CatechismClassId,
                CatechismClassCode = entity.CatechismClass.Code,
                CatechismClassName = entity.CatechismClass.Name,
                JoinDate = entity.JoinDate,
                LeaveDate = entity.LeaveDate,
                IsCurrent = entity.IsCurrent,
                Note = entity.Note
            }
        };
    }
}
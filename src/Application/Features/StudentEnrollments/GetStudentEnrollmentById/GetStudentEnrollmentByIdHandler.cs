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
        var enrollment = await _repository.GetByIdAsync(request.Id);

        if (enrollment is null)
        {
            return new GetStudentEnrollmentByIdResult
            {
                Success = false,
                Message = "Không tìm thấy phân lớp."
            };
        }

        return new GetStudentEnrollmentByIdResult
        {
            Success = true,
            Message = "Thành công.",
            Data = new GetStudentEnrollmentByIdResponse
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
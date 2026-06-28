using Domain.Interfaces;

namespace Application.Features.Semesters.UpdateSemester;

public class UpdateSemesterHandler
{
    private readonly ISemesterRepository _repository;

    public UpdateSemesterHandler(
        ISemesterRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateSemesterRequest request)
    {
        var semester = await _repository.GetByIdAsync(request.Id);

        if (semester is null)
            throw new Exception("Không tìm thấy học kỳ.");

        if (request.IsCurrent &&
            !semester.IsCurrent &&
            await _repository.ExistsCurrentAsync(semester.AcademicYearId))
        {
            throw new Exception("Đã tồn tại học kỳ hiện hành.");
        }

        semester.Name = request.Name;
        semester.SemesterOrder = request.SemesterOrder;
        semester.StartDate = request.StartDate;
        semester.EndDate = request.EndDate;
        semester.IsCurrent = request.IsCurrent;

        await _repository.UpdateAsync(semester);
    }
}
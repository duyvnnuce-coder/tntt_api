using Domain.Interfaces;

namespace Application.Features.AcademicYears.UpdateAcademicYear;

public class UpdateAcademicYearHandler
{
    private readonly IAcademicYearRepository _repository;

    public UpdateAcademicYearHandler(
        IAcademicYearRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateAcademicYearRequest request)
    {
        var academicYear = await _repository.GetByIdAsync(request.Id);

        if (academicYear is null)
            throw new Exception("Không tìm thấy năm học.");

        academicYear.Name = request.Name;
        academicYear.StartDate = request.StartDate;
        academicYear.EndDate = request.EndDate;
        academicYear.IsCurrent = request.IsCurrent;
        academicYear.DisplayOrder = request.DisplayOrder;

        await _repository.UpdateAsync(academicYear);
    }
}
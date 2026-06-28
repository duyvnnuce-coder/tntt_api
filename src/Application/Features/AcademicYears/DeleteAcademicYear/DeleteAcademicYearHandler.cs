using Domain.Interfaces;

namespace Application.Features.AcademicYears.DeleteAcademicYear;

public class DeleteAcademicYearHandler
{
    private readonly IAcademicYearRepository _repository;

    public DeleteAcademicYearHandler(
        IAcademicYearRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(Guid id)
    {
        var academicYear = await _repository.GetByIdAsync(id);

        if (academicYear is null)
            throw new Exception("Không tìm thấy năm học.");

        await _repository.DeleteAsync(academicYear);
    }
}
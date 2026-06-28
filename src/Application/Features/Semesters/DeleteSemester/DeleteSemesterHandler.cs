using Domain.Interfaces;

namespace Application.Features.Semesters.DeleteSemester;

public class DeleteSemesterHandler
{
    private readonly ISemesterRepository _repository;

    public DeleteSemesterHandler(
        ISemesterRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(Guid id)
    {
        var semester = await _repository.GetByIdAsync(id);

        if (semester is null)
            throw new Exception("Không tìm thấy học kỳ.");

        await _repository.DeleteAsync(semester);
    }
}
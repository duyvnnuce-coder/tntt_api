using Application.Common.Exceptions;
using Domain.Interfaces;

namespace Application.Features.Students.DeleteStudent;

public class DeleteStudentHandler
{
    private readonly IStudentRepository _repository;

    public DeleteStudentHandler(IStudentRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(Guid id)
    {
        var student = await _repository.GetByIdAsync(id);

        if (student is null)
            throw new NotFoundException("Không tìm thấy học sinh.");

        await _repository.DeleteAsync(student);
    }
}
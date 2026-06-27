using Domain.Interfaces;

namespace Application.Features.Teachers.DeleteTeacher;

public class DeleteTeacherHandler
{
    private readonly ITeacherRepository _teacherRepository;

    public DeleteTeacherHandler(
        ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public async Task Handle(Guid id)
    {
        var teacher = await _teacherRepository.GetByIdAsync(id);

        if (teacher is null)
            return;

        await _teacherRepository.DeleteAsync(teacher);
    }
}
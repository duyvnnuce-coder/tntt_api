using Application.Common.Exceptions;
using Domain.Interfaces;

namespace Application.Features.Students.UpdateStudent;

public class UpdateStudentHandler
{
    private readonly IStudentRepository _repository;

    public UpdateStudentHandler(IStudentRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateStudentRequest request)
    {
        var student = await _repository.GetByIdAsync(request.Id);

        if (student is null)
            throw new NotFoundException("Không tìm thấy học sinh.");

        student.ChristianName = request.ChristianName;
        student.FullName = request.FullName;
        student.Gender = request.Gender;
        student.DateOfBirth = request.DateOfBirth;
        student.Phone = request.Phone;
        student.Email = request.Email;
        student.Address = request.Address;
        student.FatherName = request.FatherName;
        student.MotherName = request.MotherName;
        student.ParentPhone = request.ParentPhone;
        student.IsActive = request.IsActive;
        student.Note = request.Note;

        await _repository.UpdateAsync(student);
    }
}
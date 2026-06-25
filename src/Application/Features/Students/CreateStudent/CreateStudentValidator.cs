using Application.Common.Exceptions;

namespace Application.Features.Students.CreateStudent;

public sealed class CreateStudentValidator
{
    public void Validate(CreateStudentRequest request)
    {
        if (request.ParishId == Guid.Empty)
            throw new AppException("Parish is required.");

        if (request.CatechismClassId == Guid.Empty)
            throw new AppException("Catechism class is required.");

        if (string.IsNullOrWhiteSpace(request.FullName))
            throw new AppException("Full name is required.");

        if (request.FullName.Length > 200)
            throw new AppException("Full name is too long.");
    }
}
namespace Application.Features.StudentEnrollments.CreateStudentEnrollment;

public static class CreateStudentEnrollmentValidator
{
    public static List<string> Validate(
        CreateStudentEnrollmentRequest request)
    {
        var errors = new List<string>();

        if (request.StudentId == Guid.Empty)
            errors.Add("StudentId is required.");

        if (request.CatechismClassId == Guid.Empty)
            errors.Add("CatechismClassId is required.");

        return errors;
    }
}
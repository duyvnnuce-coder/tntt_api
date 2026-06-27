namespace Application.Features.StudentEnrollments.UpdateStudentEnrollment;

public static class UpdateStudentEnrollmentValidator
{
    public static List<string> Validate(
        UpdateStudentEnrollmentRequest request)
    {
        var errors = new List<string>();

        if (request.Id == Guid.Empty)
            errors.Add("Id is required.");

        if (request.CatechismClassId == Guid.Empty)
            errors.Add("CatechismClassId is required.");

        return errors;
    }
}
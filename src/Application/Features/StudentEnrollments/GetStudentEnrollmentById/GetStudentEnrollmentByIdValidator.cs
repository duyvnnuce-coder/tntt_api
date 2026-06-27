namespace Application.Features.StudentEnrollments.GetStudentEnrollmentById;

public static class GetStudentEnrollmentByIdValidator
{
    public static List<string> Validate(GetStudentEnrollmentByIdRequest request)
    {
        var errors = new List<string>();

        if (request.Id == Guid.Empty)
            errors.Add("Id is required.");

        return errors;
    }
}
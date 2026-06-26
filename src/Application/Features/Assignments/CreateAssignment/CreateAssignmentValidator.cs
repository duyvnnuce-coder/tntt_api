namespace Application.Features.Assignments.CreateAssignment;

public static class CreateAssignmentValidator
{
    public static List<string> Validate(CreateAssignmentRequest request)
    {
        var errors = new List<string>();

        if (request.SemesterId == Guid.Empty)
            errors.Add("SemesterId is required.");

        if (request.CatechismClassId == Guid.Empty)
            errors.Add("CatechismClassId is required.");

        if (request.TeacherId == Guid.Empty)
            errors.Add("TeacherId is required.");

        return errors;
    }
}
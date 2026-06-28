namespace Application.Features.Assignments.CreateAssignment;

public static class CreateAssignmentValidator
{
    public static List<string> Validate(CreateAssignmentRequest request)
    {
        var errors = new List<string>();

        if (request.TeacherId == Guid.Empty)
            errors.Add("TeacherId is required.");

        if (request.CatechismClassId == Guid.Empty)
            errors.Add("CatechismClassId is required.");

        if (request.SemesterId == Guid.Empty)
            errors.Add("SemesterId is required.");

        if (request.StartDate == default)
            errors.Add("StartDate is required.");

        if (request.EndDate.HasValue &&
            request.EndDate < request.StartDate)
            errors.Add("EndDate must be greater than StartDate.");

        return errors;
    }
}
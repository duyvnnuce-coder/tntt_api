namespace Application.Features.Attendances.CreateAttendance;

public static class CreateAttendanceValidator
{
    public static List<string> Validate(
        CreateAttendanceRequest request)
    {
        var errors = new List<string>();

        if (request.AttendanceSessionId == Guid.Empty)
            errors.Add("AttendanceSessionId is required.");

        if (request.StudentId == Guid.Empty)
            errors.Add("StudentId is required.");

        return errors;
    }
}
namespace Application.Features.AttendanceSessions.CreateAttendanceSession;

public static class CreateAttendanceSessionValidator
{
    public static List<string> Validate(CreateAttendanceSessionRequest request)
    {
        var errors = new List<string>();

        if (request.AssignmentId == Guid.Empty)
            errors.Add("AssignmentId is required.");

        if (request.LessonNumber <= 0)
            errors.Add("LessonNumber must be greater than 0.");

        if (request.AttendanceDate == default)
            errors.Add("AttendanceDate is required.");

        return errors;
    }
}
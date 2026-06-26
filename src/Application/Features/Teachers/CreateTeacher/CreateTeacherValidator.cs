namespace Application.Features.Teachers.CreateTeacher;

public class CreateTeacherValidator
{
    public List<string> Validate(CreateTeacherRequest request)
    {
        var errors = new List<string>();

        if (request.ParishId == Guid.Empty)
            errors.Add("ParishId là bắt buộc.");

        if (string.IsNullOrWhiteSpace(request.FullName))
            errors.Add("Họ tên là bắt buộc.");

        return errors;
    }
}
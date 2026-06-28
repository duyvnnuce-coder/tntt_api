namespace Application.Features.Exams.CreateExam;

public static class CreateExamValidator
{
    public static string? Validate(CreateExamRequest request)
    {
        if (request.AssignmentId == Guid.Empty)
            return "Assignment không hợp lệ.";

        if (string.IsNullOrWhiteSpace(request.Name))
            return "Tên kỳ thi không được để trống.";

        if (request.MaxScore <= 0)
            return "Điểm tối đa phải lớn hơn 0.";

        return null;
    }
}
namespace Application.Features.GeneratedExams.CreateGeneratedExam;

public static class CreateGeneratedExamValidator
{
    public static string? Validate(CreateGeneratedExamRequest request)
    {
        if (request.ExamBlueprintId == Guid.Empty)
            return "Đề mẫu không hợp lệ.";

        if (string.IsNullOrWhiteSpace(request.Name))
            return "Tên đề thi không được để trống.";

        return null;
    }
}
namespace Application.Features.GeneratedExams.UpdateGeneratedExam;

public static class UpdateGeneratedExamValidator
{
    public static string? Validate(UpdateGeneratedExamRequest request)
    {
        if (request.Id == Guid.Empty)
            return "Id không hợp lệ.";

        if (request.ExamBlueprintId == Guid.Empty)
            return "Đề mẫu không hợp lệ.";

        if (string.IsNullOrWhiteSpace(request.Name))
            return "Tên đề thi không được để trống.";

        return null;
    }
}
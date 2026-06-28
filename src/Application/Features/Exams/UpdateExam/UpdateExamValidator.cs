namespace Application.Features.Exams.UpdateExam;

public static class UpdateExamValidator
{
    public static string? Validate(UpdateExamRequest request)
    {
        if (request.Id == Guid.Empty)
            return "Id không hợp lệ.";

        if (request.AssignmentId == Guid.Empty)
            return "Chưa chọn phân công.";

        if (string.IsNullOrWhiteSpace(request.Name))
            return "Tên kỳ thi không được để trống.";

        if (request.MaxScore <= 0)
            return "Điểm tối đa phải lớn hơn 0.";

        return null;
    }
}
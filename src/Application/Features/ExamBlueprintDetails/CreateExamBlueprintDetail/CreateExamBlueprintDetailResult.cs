namespace Application.Features.ExamBlueprintDetails.CreateExamBlueprintDetail;

public class CreateExamBlueprintDetailResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public CreateExamBlueprintDetailResponse? Data { get; set; }
}
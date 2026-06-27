namespace Application.Features.ExamBlueprintDetails.GetExamBlueprintDetailById;

public class GetExamBlueprintDetailByIdResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public GetExamBlueprintDetailByIdResponse? Data { get; set; }
}
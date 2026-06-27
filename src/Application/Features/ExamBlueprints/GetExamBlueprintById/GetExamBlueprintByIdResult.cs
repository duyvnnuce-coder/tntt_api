namespace Application.Features.ExamBlueprints.GetExamBlueprintById;

public class GetExamBlueprintByIdResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public GetExamBlueprintByIdResponse? Data { get; set; }
}
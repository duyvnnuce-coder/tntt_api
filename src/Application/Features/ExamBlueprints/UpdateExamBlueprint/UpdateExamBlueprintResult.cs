namespace Application.Features.ExamBlueprints.UpdateExamBlueprint;

public class UpdateExamBlueprintResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public UpdateExamBlueprintResponse? Data { get; set; }
}
namespace Application.Features.ExamBlueprints.CreateExamBlueprint;

public class CreateExamBlueprintResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public CreateExamBlueprintResponse? Data { get; set; }
}
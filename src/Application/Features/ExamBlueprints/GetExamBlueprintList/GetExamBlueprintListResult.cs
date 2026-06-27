namespace Application.Features.ExamBlueprints.GetExamBlueprintList;

public class GetExamBlueprintListResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public List<GetExamBlueprintListResponse> Data { get; set; } = new();
}
namespace Application.Features.ExamBlueprintDetails.GetExamBlueprintDetailList;

public class GetExamBlueprintDetailListResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public List<GetExamBlueprintDetailListResponse> Data { get; set; } = [];
}
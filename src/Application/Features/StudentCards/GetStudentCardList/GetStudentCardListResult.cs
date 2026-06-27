namespace Application.Features.StudentCards.GetStudentCardList;

public class GetStudentCardListResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public List<GetStudentCardListResponse> Data { get; set; } = new();
}
namespace Application.Features.StudentCards.GetStudentCardList;

public class GetStudentCardListRequest
{
    public string? Keyword { get; set; }

    public bool? IsActive { get; set; }
}
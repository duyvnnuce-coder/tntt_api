namespace Application.Features.Exams.GetExamList;

public class GetExamListRequest
{
    public string? Keyword { get; set; }

    public Guid? AssignmentId { get; set; }

    public bool? IsPublished { get; set; }
}
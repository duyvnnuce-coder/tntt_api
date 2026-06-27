namespace Application.Features.ExamBlueprints.GetExamBlueprintById;

public class GetExamBlueprintByIdResponse
{
    public Guid Id { get; set; }

    public Guid CatechismGradeId { get; set; }

    public string CatechismGradeCode { get; set; } = string.Empty;

    public string CatechismGradeName { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public int TotalQuestions { get; set; }

    public int DurationMinutes { get; set; }

    public bool IsActive { get; set; }
}
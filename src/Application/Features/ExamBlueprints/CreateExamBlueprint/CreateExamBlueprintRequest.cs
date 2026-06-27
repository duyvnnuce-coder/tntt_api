namespace Application.Features.ExamBlueprints.CreateExamBlueprint;

public class CreateExamBlueprintRequest
{
    public Guid CatechismGradeId { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public int TotalQuestions { get; set; }

    public int DurationMinutes { get; set; }

    public bool IsActive { get; set; } = true;
}
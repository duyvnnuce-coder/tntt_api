namespace Application.Features.ExamBlueprints.UpdateExamBlueprint;

public class UpdateExamBlueprintRequest
{
    public Guid Id { get; set; }

    public Guid CatechismGradeId { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public int TotalQuestions { get; set; }

    public int DurationMinutes { get; set; }

    public bool IsActive { get; set; }
}
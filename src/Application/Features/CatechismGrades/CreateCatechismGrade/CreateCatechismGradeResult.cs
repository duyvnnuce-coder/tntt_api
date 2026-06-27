namespace Application.Features.CatechismGrades.CreateCatechismGrade;

public class CreateCatechismGradeResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public CreateCatechismGradeResponse? Data { get; set; }
}
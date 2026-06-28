namespace Application.Features.CatechismGrades.GetCatechismGradeById;

public class GetCatechismGradeByIdResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public GetCatechismGradeByIdResponse? Data { get; set; }
}
namespace Application.Features.CatechismClasses.GetCatechismClassById;

public class GetCatechismClassByIdResponse
{
    public Guid Id { get; set; }

    public Guid ParishId { get; set; }

    public Guid AcademicYearId { get; set; }

    public Guid CatechismGradeId { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }

    public int MaxStudents { get; set; }

    public bool IsActive { get; set; }
}
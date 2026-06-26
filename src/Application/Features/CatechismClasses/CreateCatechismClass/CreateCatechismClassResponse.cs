namespace Application.Features.CatechismClasses.CreateCatechismClass;

public class CreateCatechismClassResponse
{
    public Guid Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
}
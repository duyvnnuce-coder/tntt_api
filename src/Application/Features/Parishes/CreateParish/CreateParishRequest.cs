namespace Application.Features.Parishes.CreateParish;

public class CreateParishCommand
{
    public string Name { get; set; } = string.Empty;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Description { get; set; }
}

public class CreateParishResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
}

public class CreateParishResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public CreateParishResponse? Data { get; set; }
}
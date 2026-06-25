using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class StudentCard : BaseEntity
{
    public Guid StudentId { get; set; }

    public string Token { get; set; } = string.Empty;

    public DateOnly IssuedDate { get; set; }

    public DateOnly? ExpiredDate { get; set; }

    public StudentCardStatus Status { get; set; } = StudentCardStatus.Active;

    public int PrintCount { get; set; }

    // Navigation
    public Student Student { get; set; } = null!;
}
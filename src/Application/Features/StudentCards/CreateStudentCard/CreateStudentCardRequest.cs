using System.ComponentModel.DataAnnotations;

namespace Application.Features.StudentCards.CreateStudentCard;

public class CreateStudentCardRequest
{
    [Required]
    public Guid StudentId { get; set; }

    [Required]
    [MaxLength(50)]
    public string CardNumber { get; set; } = string.Empty;

    [Required]
    public DateOnly IssueDate { get; set; }

    public DateOnly? ExpiryDate { get; set; }
}
using Domain.Enums;
using Domain.Interfaces;

namespace Application.Features.StudentCards.ReissueStudentCard;

public class ReissueStudentCardHandler
{
    private readonly IStudentCardRepository _repository;

    public ReissueStudentCardHandler(
        IStudentCardRepository repository)
    {
        _repository = repository;
    }

    public async Task<ReissueStudentCardResult> Handle(
        ReissueStudentCardRequest request)
    {
        var errors = ReissueStudentCardValidator.Validate(request);

        if (errors.Any())
        {
            return new ReissueStudentCardResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var card = await _repository.GetByIdAsync(request.StudentCardId);

        if (card == null)
        {
            return new ReissueStudentCardResult
            {
                Success = false,
                Message = "Student card not found."
            };
        }

        // Nghiệp vụ đã chốt:
        // - Giữ nguyên CardNumber
        // - Sinh Token mới
        // - Tăng PrintCount
        // - Đặt Active

        card.Token = Guid.NewGuid().ToString("N");
        card.PrintCount++;
        card.Status = StudentCardStatus.Active;

        await _repository.UpdateAsync(card);

        return new ReissueStudentCardResult
        {
            Success = true,
            Message = "Student card reissued successfully.",
            Data = new ReissueStudentCardResponse
            {
                Id = card.Id,
                Token = card.Token,
                CardNumber = card.CardNumber,
                PrintCount = card.PrintCount,
                Status = card.Status
            }
        };
    }
}
using Domain.Interfaces;

namespace Application.Features.StudentCards.UpdateStudentCardStatus;

public class UpdateStudentCardStatusHandler
{
    private readonly IStudentCardRepository _repository;

    public UpdateStudentCardStatusHandler(
        IStudentCardRepository repository)
    {
        _repository = repository;
    }

    public async Task<UpdateStudentCardStatusResult> Handle(
        UpdateStudentCardStatusRequest request)
    {
        var errors = UpdateStudentCardStatusValidator.Validate(request);

        if (errors.Any())
        {
            return new UpdateStudentCardStatusResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var card = await _repository.GetByIdAsync(request.Id);

        if (card == null)
        {
            return new UpdateStudentCardStatusResult
            {
                Success = false,
                Message = "Student card not found."
            };
        }

        card.Status = request.Status;

        await _repository.UpdateAsync(card);

        return new UpdateStudentCardStatusResult
        {
            Success = true,
            Message = "Student card status updated successfully.",
            Data = new UpdateStudentCardStatusResponse
            {
                Id = card.Id,
                Status = card.Status
            }
        };
    }
}
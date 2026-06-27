using Domain.Interfaces;

namespace Application.Features.StudentCards.GetStudentCardByStudentId;

public class GetStudentCardByStudentIdHandler
{
    private readonly IStudentCardRepository _repository;

    public GetStudentCardByStudentIdHandler(
        IStudentCardRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetStudentCardByStudentIdResult> Handle(
        GetStudentCardByStudentIdRequest request)
    {
        var errors =
            GetStudentCardByStudentIdValidator.Validate(request);

        if (errors.Any())
        {
            return new GetStudentCardByStudentIdResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var studentCard =
            await _repository.GetByStudentIdAsync(request.StudentId);

        if (studentCard == null)
        {
            return new GetStudentCardByStudentIdResult
            {
                Success = false,
                Message = "Student card not found."
            };
        }

        return new GetStudentCardByStudentIdResult
        {
            Success = true,
            Message = "Success.",
            Data = new GetStudentCardByStudentIdResponse
            {
                Id = studentCard.Id,
                StudentId = studentCard.StudentId,

                StudentCode = studentCard.Student.Code,
                ChristianName = studentCard.Student.ChristianName,
                FullName = studentCard.Student.FullName,

                Token = studentCard.Token,
                CardNumber = studentCard.CardNumber,

                IssuedDate = studentCard.IssuedDate,
                ExpiredDate = studentCard.ExpiredDate,

                Status = studentCard.Status,
                PrintCount = studentCard.PrintCount
            }
        };
    }
}
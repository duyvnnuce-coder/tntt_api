using Domain.Interfaces;

namespace Application.Features.StudentCards.GetStudentCardById;

public class GetStudentCardByIdHandler
{
    private readonly IStudentCardRepository _repository;

    public GetStudentCardByIdHandler(IStudentCardRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetStudentCardByIdResult> Handle(GetStudentCardByIdRequest request)
    {
        var errors = GetStudentCardByIdValidator.Validate(request);

        if (errors.Any())
        {
            return new GetStudentCardByIdResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity == null)
        {
            return new GetStudentCardByIdResult
            {
                Success = false,
                Message = "Không tìm thấy thẻ."
            };
        }

        return new GetStudentCardByIdResult
        {
            Success = true,
            Message = "Thành công.",
            Data = new GetStudentCardByIdResponse
            {
                Id = entity.Id,
                StudentId = entity.StudentId,
                Token = entity.Token,
                CardNumber = entity.CardNumber,
                IssuedDate = entity.IssuedDate,
                ExpiredDate = entity.ExpiredDate,
                Status = entity.Status,
                PrintCount = entity.PrintCount
            }
        };
    }
}
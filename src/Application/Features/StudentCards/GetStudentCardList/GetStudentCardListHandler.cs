using Domain.Interfaces;

namespace Application.Features.StudentCards.GetStudentCardList;

public class GetStudentCardListHandler
{
    private readonly IStudentCardRepository _repository;

    public GetStudentCardListHandler(IStudentCardRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetStudentCardListResult> Handle(
        GetStudentCardListRequest request)
    {
        var errors = GetStudentCardListValidator.Validate(request);

        if (errors.Any())
        {
            return new GetStudentCardListResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var data = await _repository.GetListAsync();

        if (!string.IsNullOrWhiteSpace(request.Keyword))
        {
            var keyword = request.Keyword.Trim().ToLower();

            data = data.Where(x =>
                    x.Student.Code.ToLower().Contains(keyword)
                    || x.Student.FullName.ToLower().Contains(keyword)
                    || x.Student.ChristianName.ToLower().Contains(keyword)
                    || (x.CardNumber != null &&
                        x.CardNumber.ToLower().Contains(keyword)))
                .ToList();
        }

        if (request.IsActive.HasValue)
        {
            data = data.Where(x =>
                    request.IsActive.Value
                        ? x.Status == Domain.Enums.StudentCardStatus.Active
                        : x.Status != Domain.Enums.StudentCardStatus.Active)
                .ToList();
        }

        return new GetStudentCardListResult
        {
            Success = true,
            Message = "Thành công.",
            Data = data.Select(x => new GetStudentCardListResponse
            {
                Id = x.Id,
                StudentId = x.StudentId,
                StudentCode = x.Student.Code,
                ChristianName = x.Student.ChristianName,
                FullName = x.Student.FullName,
                CardNumber = x.CardNumber,
                IssuedDate = x.IssuedDate,
                ExpiredDate = x.ExpiredDate,
                Status = x.Status,
                PrintCount = x.PrintCount
            }).ToList()
        };
    }
}
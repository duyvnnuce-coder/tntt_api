using Domain.Interfaces;

namespace Application.Features.Sacraments.GetSacramentList;

public class GetSacramentListHandler
{
    private readonly ISacramentRepository _repository;

    public GetSacramentListHandler(ISacramentRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetSacramentListResult> Handle(GetSacramentListRequest request)
    {
        var errors = GetSacramentListValidator.Validate(request);

        if (errors.Any())
        {
            return new GetSacramentListResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var entities = await _repository.GetListAsync(request.StudentId);

        var data = entities
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(x => new GetSacramentListResponse
            {
                Id = x.Id,
                StudentId = x.StudentId,
                Type = x.Type,
                ReceivedDate = x.ReceivedDate,
                ChurchName = x.ChurchName
            })
            .ToList();

        return new GetSacramentListResult
        {
            Success = true,
            Message = "Lấy danh sách thành công.",
            Data = data
        };
    }
}
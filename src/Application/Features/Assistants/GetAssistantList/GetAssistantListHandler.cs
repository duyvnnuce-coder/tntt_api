using Domain.Interfaces;

namespace Application.Features.Assistants.GetAssistantList;

public class GetAssistantListHandler
{
    private readonly IAssistantRepository _repository;

    public GetAssistantListHandler(
        IAssistantRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetAssistantListResult> Handle()
    {
        var assistants = await _repository.GetListAsync();

        return new GetAssistantListResult
        {
            Success = true,
            Message = "Lấy danh sách trợ giảng thành công.",
            Data = assistants.Select(x => new GetAssistantListResponse
            {
                Id = x.Id,
                Code = x.Code,
                ChristianName = x.ChristianName,
                FullName = x.FullName,
                Gender = x.Gender,
                Phone = x.Phone,
                IsActive = x.IsActive
            }).ToList()
        };
    }
}
using Domain.Interfaces;

namespace Application.Features.QuestionCategories.GetQuestionCategoryList;

public class GetQuestionCategoryListHandler
{
    private readonly IQuestionCategoryRepository _repository;

    public GetQuestionCategoryListHandler(
        IQuestionCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetQuestionCategoryListResponse>> Handle(
        GetQuestionCategoryListRequest request)
    {
        var data = await _repository.GetListAsync();

        return data.Select(x => new GetQuestionCategoryListResponse
        {
            Id = x.Id,
            ParishId = x.ParishId,
            Code = x.Code,
            Name = x.Name,
            Description = x.Description,
            IsActive = x.IsActive
        }).ToList();
    }
}
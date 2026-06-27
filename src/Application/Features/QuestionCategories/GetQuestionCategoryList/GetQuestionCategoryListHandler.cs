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

    public async Task<GetQuestionCategoryListResult> Handle(
        GetQuestionCategoryListRequest request)
    {
        var errors =
            GetQuestionCategoryListValidator.Validate(request);

        if (errors.Any())
        {
            return new GetQuestionCategoryListResult
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
                    x.Code.ToLower().Contains(keyword)
                    || x.Name.ToLower().Contains(keyword)
                    || x.Parish.Code.ToLower().Contains(keyword)
                    || x.Parish.Name.ToLower().Contains(keyword))
                .ToList();
        }

        if (request.IsActive.HasValue)
        {
            data = data.Where(x =>
                    x.IsActive == request.IsActive.Value)
                .ToList();
        }

        return new GetQuestionCategoryListResult
        {
            Success = true,
            Message = "Success.",
            Data = data.Select(x => new GetQuestionCategoryListResponse
            {
                Id = x.Id,
                ParishId = x.ParishId,
                ParishCode = x.Parish.Code,
                ParishName = x.Parish.Name,
                Code = x.Code,
                Name = x.Name,
                Description = x.Description,
                IsActive = x.IsActive
            }).ToList()
        };
    }
}
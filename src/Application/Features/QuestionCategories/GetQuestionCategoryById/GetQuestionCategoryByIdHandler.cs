using Domain.Interfaces;

namespace Application.Features.QuestionCategories.GetQuestionCategoryById;

public class GetQuestionCategoryByIdHandler
{
    private readonly IQuestionCategoryRepository _repository;

    public GetQuestionCategoryByIdHandler(
        IQuestionCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetQuestionCategoryByIdResult> Handle(
        GetQuestionCategoryByIdRequest request)
    {
        var errors =
            GetQuestionCategoryByIdValidator.Validate(request);

        if (errors.Any())
        {
            return new GetQuestionCategoryByIdResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity == null)
        {
            return new GetQuestionCategoryByIdResult
            {
                Success = false,
                Message = "Question category not found."
            };
        }

        return new GetQuestionCategoryByIdResult
        {
            Success = true,
            Message = "Success.",
            Data = new GetQuestionCategoryByIdResponse
            {
                Id = entity.Id,
                ParishId = entity.ParishId,
                ParishCode = entity.Parish.Code,
                ParishName = entity.Parish.Name,
                Code = entity.Code,
                Name = entity.Name,
                Description = entity.Description,
                IsActive = entity.IsActive
            }
        };
    }
}
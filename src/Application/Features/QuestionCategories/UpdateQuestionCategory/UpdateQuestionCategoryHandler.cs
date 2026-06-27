using Domain.Interfaces;

namespace Application.Features.QuestionCategories.UpdateQuestionCategory;

public class UpdateQuestionCategoryHandler
{
    private readonly IQuestionCategoryRepository _repository;
    private readonly IParishRepository _parishRepository;

    public UpdateQuestionCategoryHandler(
        IQuestionCategoryRepository repository,
        IParishRepository parishRepository)
    {
        _repository = repository;
        _parishRepository = parishRepository;
    }

    public async Task<UpdateQuestionCategoryResult> Handle(
        UpdateQuestionCategoryRequest request)
    {
        var errors =
            UpdateQuestionCategoryValidator.Validate(request);

        if (errors.Any())
        {
            return new UpdateQuestionCategoryResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity == null)
        {
            return new UpdateQuestionCategoryResult
            {
                Success = false,
                Message = "Question category not found."
            };
        }

        var parish = await _parishRepository.GetByIdAsync(request.ParishId);

        if (parish == null)
        {
            return new UpdateQuestionCategoryResult
            {
                Success = false,
                Message = "Parish not found."
            };
        }

        entity.ParishId = request.ParishId;
        entity.Code = request.Code.Trim();
        entity.Name = request.Name.Trim();
        entity.Description = request.Description;
        entity.IsActive = request.IsActive;

        await _repository.UpdateAsync(entity);

        return new UpdateQuestionCategoryResult
        {
            Success = true,
            Message = "Question category updated successfully.",
            Data = new UpdateQuestionCategoryResponse
            {
                Id = entity.Id,
                ParishId = entity.ParishId,
                ParishCode = parish.Code,
                ParishName = parish.Name,
                Code = entity.Code,
                Name = entity.Name,
                Description = entity.Description,
                IsActive = entity.IsActive
            }
        };
    }
}
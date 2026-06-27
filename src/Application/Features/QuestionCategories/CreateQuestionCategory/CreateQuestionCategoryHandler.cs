using Domain.Entities;
using Domain.Interfaces;

namespace Application.Features.QuestionCategories.CreateQuestionCategory;

public class CreateQuestionCategoryHandler
{
    private readonly IParishRepository _parishRepository;
    private readonly IQuestionCategoryRepository _repository;

    public CreateQuestionCategoryHandler(
        IParishRepository parishRepository,
        IQuestionCategoryRepository repository)
    {
        _parishRepository = parishRepository;
        _repository = repository;
    }

    public async Task<CreateQuestionCategoryResult> Handle(
        CreateQuestionCategoryRequest request)
    {
        var errors =
            CreateQuestionCategoryValidator.Validate(request);

        if (errors.Any())
        {
            return new CreateQuestionCategoryResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var parish = await _parishRepository.GetByIdAsync(request.ParishId);

        if (parish == null)
        {
            return new CreateQuestionCategoryResult
            {
                Success = false,
                Message = "Parish not found."
            };
        }

        var entity = new QuestionCategory
        {
            ParishId = request.ParishId,
            Code = request.Code.Trim(),
            Name = request.Name.Trim(),
            Description = request.Description,
            IsActive = request.IsActive
        };

        await _repository.AddAsync(entity);

        return new CreateQuestionCategoryResult
        {
            Success = true,
            Message = "Question category created successfully.",
            Data = new CreateQuestionCategoryResponse
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
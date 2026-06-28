using Application.Common.Enums;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Features.QuestionCategories.CreateQuestionCategory;

public class CreateQuestionCategoryHandler
{
    private readonly IQuestionCategoryRepository _repository;
    private readonly ICodeGenerator _codeGenerator;

    public CreateQuestionCategoryHandler(
        IQuestionCategoryRepository repository,
        ICodeGenerator codeGenerator)
    {
        _repository = repository;
        _codeGenerator = codeGenerator;
    }

    public async Task<CreateQuestionCategoryResult> Handle(
        CreateQuestionCategoryRequest request)
    {
        if (await _repository.ExistsNameAsync(
            request.ParishId,
            request.Name))
        {
            return new CreateQuestionCategoryResult
            {
                Success = false,
                Message = "Tên nhóm câu hỏi đã tồn tại."
            };
        }

        var code = await _codeGenerator.GenerateAsync(
            CodeType.QuestionCategory,
            request.ParishId);

        var category = new QuestionCategory
        {
            Id = Guid.NewGuid(),
            ParishId = request.ParishId,
            Code = code,
            Name = request.Name,
            Description = request.Description,
            IsActive = request.IsActive
        };

        await _repository.AddAsync(category);

        return new CreateQuestionCategoryResult
        {
            Success = true,
            Message = "Tạo nhóm câu hỏi thành công.",
            Data = new CreateQuestionCategoryResponse
            {
                Id = category.Id,
                Code = category.Code,
                Name = category.Name
            }
        };
    }
}
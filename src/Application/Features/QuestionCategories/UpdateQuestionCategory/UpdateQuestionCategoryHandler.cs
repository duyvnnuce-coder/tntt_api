using Domain.Interfaces;

namespace Application.Features.QuestionCategories.UpdateQuestionCategory;

public class UpdateQuestionCategoryHandler
{
    private readonly IQuestionCategoryRepository _repository;

    public UpdateQuestionCategoryHandler(
        IQuestionCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<UpdateQuestionCategoryResult> Handle(
        UpdateQuestionCategoryRequest request)
    {
        var category = await _repository.GetByIdAsync(request.Id);

        if (category is null)
        {
            return new UpdateQuestionCategoryResult
            {
                Success = false,
                Message = "Không tìm thấy nhóm câu hỏi."
            };
        }

        if (!string.Equals(
                category.Name,
                request.Name,
                StringComparison.OrdinalIgnoreCase))
        {
            if (await _repository.ExistsNameAsync(
                    category.ParishId,
                    request.Name))
            {
                return new UpdateQuestionCategoryResult
                {
                    Success = false,
                    Message = "Tên nhóm câu hỏi đã tồn tại."
                };
            }
        }

        category.Name = request.Name;
        category.Description = request.Description;
        category.IsActive = request.IsActive;

        await _repository.UpdateAsync(category);

        return new UpdateQuestionCategoryResult
        {
            Success = true,
            Message = "Cập nhật nhóm câu hỏi thành công."
        };
    }
}
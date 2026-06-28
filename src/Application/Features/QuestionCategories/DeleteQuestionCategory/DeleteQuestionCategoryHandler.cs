using Domain.Interfaces;

namespace Application.Features.QuestionCategories.DeleteQuestionCategory;

public class DeleteQuestionCategoryHandler
{
    private readonly IQuestionCategoryRepository _repository;

    public DeleteQuestionCategoryHandler(
        IQuestionCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<DeleteQuestionCategoryResult> Handle(
        DeleteQuestionCategoryRequest request)
    {
        var category = await _repository.GetByIdAsync(request.Id);

        if (category is null)
        {
            return new DeleteQuestionCategoryResult
            {
                Success = false,
                Message = "Không tìm thấy nhóm câu hỏi."
            };
        }

        await _repository.DeleteAsync(category);

        return new DeleteQuestionCategoryResult
        {
            Success = true,
            Message = "Xóa nhóm câu hỏi thành công."
        };
    }
}
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
        var category = await _repository.GetByIdAsync(request.Id);

        if (category is null)
        {
            return new GetQuestionCategoryByIdResult
            {
                Success = false,
                Message = "Không tìm thấy nhóm câu hỏi."
            };
        }

        return new GetQuestionCategoryByIdResult
        {
            Success = true,
            Message = "Lấy thông tin thành công.",
            Data = new GetQuestionCategoryByIdResponse
            {
                Id = category.Id,
                ParishId = category.ParishId,
                Code = category.Code,
                Name = category.Name,
                Description = category.Description,
                IsActive = category.IsActive
            }
        };
    }
}
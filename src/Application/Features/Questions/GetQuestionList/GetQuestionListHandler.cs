using Domain.Interfaces;

namespace Application.Features.Questions.GetQuestionList;

public class GetQuestionListHandler
{
    private readonly IQuestionRepository _repository;

    public GetQuestionListHandler(
        IQuestionRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetQuestionListResponse>> Handle(
        GetQuestionListRequest request)
    {
        var data = await _repository.GetListAsync();

        return data.Select(x => new GetQuestionListResponse
        {
            Id = x.Id,

            QuestionCategoryId = x.QuestionCategoryId,
            CategoryName = x.QuestionCategory.Name,
            Code = x.Code,
            Content = x.Content,
            CorrectAnswer = x.CorrectAnswer,
            DifficultyLevel = x.DifficultyLevel,
            IsActive = x.IsActive
        }).ToList();
    }
}
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

    public async Task<GetQuestionListResult> Handle(
        GetQuestionListRequest request)
    {
        var errors = GetQuestionListValidator.Validate(request);

        if (errors.Any())
        {
            return new GetQuestionListResult
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
                    || x.Content.ToLower().Contains(keyword)
                    || x.QuestionCategory.Code.ToLower().Contains(keyword)
                    || x.QuestionCategory.Name.ToLower().Contains(keyword)
                    || x.CatechismGrade.Code.ToLower().Contains(keyword)
                    || x.CatechismGrade.Name.ToLower().Contains(keyword))
                .ToList();
        }

        if (request.QuestionCategoryId.HasValue)
        {
            data = data.Where(x =>
                    x.QuestionCategoryId == request.QuestionCategoryId.Value)
                .ToList();
        }

        if (request.CatechismGradeId.HasValue)
        {
            data = data.Where(x =>
                    x.CatechismGradeId == request.CatechismGradeId.Value)
                .ToList();
        }

        if (request.IsActive.HasValue)
        {
            data = data.Where(x =>
                    x.IsActive == request.IsActive.Value)
                .ToList();
        }

        return new GetQuestionListResult
        {
            Success = true,
            Message = "Success.",
            Data = data.Select(x => new GetQuestionListResponse
            {
                Id = x.Id,
                QuestionCategoryId = x.QuestionCategoryId,
                QuestionCategoryCode = x.QuestionCategory.Code,
                QuestionCategoryName = x.QuestionCategory.Name,
                CatechismGradeId = x.CatechismGradeId,
                CatechismGradeCode = x.CatechismGrade.Code,
                CatechismGradeName = x.CatechismGrade.Name,
                Code = x.Code,
                Content = x.Content,
                CorrectAnswer = x.CorrectAnswer,
                DifficultyLevel = x.DifficultyLevel,
                IsActive = x.IsActive
            }).ToList()
        };
    }
}
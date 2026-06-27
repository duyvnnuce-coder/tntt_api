using Domain.Interfaces;

namespace Application.Features.Questions.GetQuestionById;

public class GetQuestionByIdHandler
{
    private readonly IQuestionRepository _repository;

    public GetQuestionByIdHandler(
        IQuestionRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetQuestionByIdResult> Handle(
        GetQuestionByIdRequest request)
    {
        var errors = GetQuestionByIdValidator.Validate(request);

        if (errors.Any())
        {
            return new GetQuestionByIdResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity == null)
        {
            return new GetQuestionByIdResult
            {
                Success = false,
                Message = "Question not found."
            };
        }

        return new GetQuestionByIdResult
        {
            Success = true,
            Message = "Success.",
            Data = new GetQuestionByIdResponse
            {
                Id = entity.Id,
                QuestionCategoryId = entity.QuestionCategoryId,
                QuestionCategoryCode = entity.QuestionCategory.Code,
                QuestionCategoryName = entity.QuestionCategory.Name,
                CatechismGradeId = entity.CatechismGradeId,
                CatechismGradeCode = entity.CatechismGrade.Code,
                CatechismGradeName = entity.CatechismGrade.Name,
                Code = entity.Code,
                Content = entity.Content,
                AnswerA = entity.AnswerA,
                AnswerB = entity.AnswerB,
                AnswerC = entity.AnswerC,
                AnswerD = entity.AnswerD,
                CorrectAnswer = entity.CorrectAnswer,
                DifficultyLevel = entity.DifficultyLevel,
                IsActive = entity.IsActive
            }
        };
    }
}
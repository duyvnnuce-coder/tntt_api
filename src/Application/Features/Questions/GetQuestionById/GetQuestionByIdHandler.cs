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
        var question = await _repository.GetByIdAsync(request.Id);

        if (question is null)
        {
            return new GetQuestionByIdResult
            {
                Success = false,
                Message = "Không tìm thấy câu hỏi."
            };
        }

        return new GetQuestionByIdResult
        {
            Success = true,
            Message = "Lấy thông tin câu hỏi thành công.",
            Data = new GetQuestionByIdResponse
            {
                Id = question.Id,
                QuestionCategoryId = question.QuestionCategoryId,
                CategoryName = question.QuestionCategory.Name,
                Code = question.Code,
                Content = question.Content,
                AnswerA = question.AnswerA,
                AnswerB = question.AnswerB,
                AnswerC = question.AnswerC,
                AnswerD = question.AnswerD,
                CorrectAnswer = question.CorrectAnswer,
                DifficultyLevel = question.DifficultyLevel,
                IsActive = question.IsActive
            }
        };
    }
}
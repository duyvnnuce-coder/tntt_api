using Domain.Interfaces;

namespace Application.Features.Questions.UpdateQuestion;

public class UpdateQuestionHandler
{
    private readonly IQuestionRepository _repository;
    private readonly IQuestionCategoryRepository _categoryRepository;

    public UpdateQuestionHandler(
        IQuestionRepository repository,
        IQuestionCategoryRepository categoryRepository)
    {
        _repository = repository;
        _categoryRepository = categoryRepository;
    }

    public async Task<UpdateQuestionResult> Handle(
        UpdateQuestionRequest request)
    {
        var question = await _repository.GetByIdAsync(request.Id);

        if (question is null)
        {
            return new UpdateQuestionResult
            {
                Success = false,
                Message = "Không tìm thấy câu hỏi."
            };
        }

        var category = await _categoryRepository.GetByIdAsync(
            request.QuestionCategoryId);

        if (category is null)
        {
            return new UpdateQuestionResult
            {
                Success = false,
                Message = "Không tìm thấy nhóm câu hỏi."
            };
        }

        question.QuestionCategoryId = request.QuestionCategoryId;
        question.Content = request.Content;
        question.AnswerA = request.AnswerA;
        question.AnswerB = request.AnswerB;
        question.AnswerC = request.AnswerC;
        question.AnswerD = request.AnswerD;
        question.CorrectAnswer = request.CorrectAnswer;
        question.DifficultyLevel = request.DifficultyLevel;
        question.IsActive = request.IsActive;

        await _repository.UpdateAsync(question);

        return new UpdateQuestionResult
        {
            Success = true,
            Message = "Cập nhật câu hỏi thành công."
        };
    }
}
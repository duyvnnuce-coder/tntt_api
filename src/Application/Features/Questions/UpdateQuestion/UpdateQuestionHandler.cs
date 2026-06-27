using Domain.Interfaces;

namespace Application.Features.Questions.UpdateQuestion;

public class UpdateQuestionHandler
{
    private readonly IQuestionRepository _repository;
    private readonly IQuestionCategoryRepository _categoryRepository;
    private readonly ICatechismGradeRepository _gradeRepository;

    public UpdateQuestionHandler(
        IQuestionRepository repository,
        IQuestionCategoryRepository categoryRepository,
        ICatechismGradeRepository gradeRepository)
    {
        _repository = repository;
        _categoryRepository = categoryRepository;
        _gradeRepository = gradeRepository;
    }

    public async Task<UpdateQuestionResult> Handle(
        UpdateQuestionRequest request)
    {
        var errors = UpdateQuestionValidator.Validate(request);

        if (errors.Any())
        {
            return new UpdateQuestionResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity == null)
        {
            return new UpdateQuestionResult
            {
                Success = false,
                Message = "Question not found."
            };
        }

        var category = await _categoryRepository.GetByIdAsync(
            request.QuestionCategoryId);

        if (category == null)
        {
            return new UpdateQuestionResult
            {
                Success = false,
                Message = "Question category not found."
            };
        }

        var grade = await _gradeRepository.GetByIdAsync(
            request.CatechismGradeId);

        if (grade == null)
        {
            return new UpdateQuestionResult
            {
                Success = false,
                Message = "Catechism grade not found."
            };
        }

        entity.QuestionCategoryId = request.QuestionCategoryId;
        entity.CatechismGradeId = request.CatechismGradeId;
        entity.Code = request.Code.Trim();
        entity.Content = request.Content.Trim();
        entity.AnswerA = request.AnswerA.Trim();
        entity.AnswerB = request.AnswerB.Trim();
        entity.AnswerC = request.AnswerC;
        entity.AnswerD = request.AnswerD;
        entity.CorrectAnswer = request.CorrectAnswer.Trim().ToUpper();
        entity.DifficultyLevel = request.DifficultyLevel;
        entity.IsActive = request.IsActive;

        await _repository.UpdateAsync(entity);

        return new UpdateQuestionResult
        {
            Success = true,
            Message = "Question updated successfully.",
            Data = new UpdateQuestionResponse
            {
                Id = entity.Id,
                QuestionCategoryId = entity.QuestionCategoryId,
                QuestionCategoryCode = category.Code,
                QuestionCategoryName = category.Name,
                CatechismGradeId = entity.CatechismGradeId,
                CatechismGradeCode = grade.Code,
                CatechismGradeName = grade.Name,
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
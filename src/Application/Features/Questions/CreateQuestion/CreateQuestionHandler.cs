using Domain.Entities;
using Domain.Interfaces;

namespace Application.Features.Questions.CreateQuestion;

public class CreateQuestionHandler
{
    private readonly IQuestionRepository _repository;
    private readonly IQuestionCategoryRepository _categoryRepository;
    private readonly ICatechismGradeRepository _gradeRepository;

    public CreateQuestionHandler(
        IQuestionRepository repository,
        IQuestionCategoryRepository categoryRepository,
        ICatechismGradeRepository gradeRepository)
    {
        _repository = repository;
        _categoryRepository = categoryRepository;
        _gradeRepository = gradeRepository;
    }

    public async Task<CreateQuestionResult> Handle(
        CreateQuestionRequest request)
    {
        var errors = CreateQuestionValidator.Validate(request);

        if (errors.Any())
        {
            return new CreateQuestionResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var category =
            await _categoryRepository.GetByIdAsync(request.QuestionCategoryId);

        if (category == null)
        {
            return new CreateQuestionResult
            {
                Success = false,
                Message = "Question category not found."
            };
        }

        var grade =
            await _gradeRepository.GetByIdAsync(request.CatechismGradeId);

        if (grade == null)
        {
            return new CreateQuestionResult
            {
                Success = false,
                Message = "Catechism grade not found."
            };
        }

        var entity = new Question
        {
            QuestionCategoryId = request.QuestionCategoryId,
            CatechismGradeId = request.CatechismGradeId,
            Code = request.Code.Trim(),
            Content = request.Content.Trim(),
            AnswerA = request.AnswerA.Trim(),
            AnswerB = request.AnswerB.Trim(),
            AnswerC = request.AnswerC,
            AnswerD = request.AnswerD,
            CorrectAnswer = request.CorrectAnswer.Trim().ToUpper(),
            DifficultyLevel = request.DifficultyLevel,
            IsActive = request.IsActive
        };

        await _repository.AddAsync(entity);

        return new CreateQuestionResult
        {
            Success = true,
            Message = "Question created successfully.",
            Data = new CreateQuestionResponse
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
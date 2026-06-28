using Application.Common.Enums;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Features.Questions.CreateQuestion;

public class CreateQuestionHandler
{
    private readonly IQuestionRepository _repository;
    private readonly IQuestionCategoryRepository _categoryRepository;
    private readonly ICodeGenerator _codeGenerator;

    public CreateQuestionHandler(
        IQuestionRepository repository,
        IQuestionCategoryRepository categoryRepository,
        ICodeGenerator codeGenerator)
    {
        _repository = repository;
        _categoryRepository = categoryRepository;
        _codeGenerator = codeGenerator;
    }

    public async Task<CreateQuestionResult> Handle(
        CreateQuestionRequest request)
    {
        var category = await _categoryRepository.GetByIdAsync(
            request.QuestionCategoryId);

        if (category is null)
        {
            return new CreateQuestionResult
            {
                Success = false,
                Message = "Không tìm thấy nhóm câu hỏi."
            };
        }

        var code = await _codeGenerator.GenerateAsync(
            CodeType.Question,
            request.ParishId);

        var question = new Question
        {
            Id = Guid.NewGuid(),

            QuestionCategoryId = request.QuestionCategoryId,
            Code = code,
            Content = request.Content,
           AnswerA = request.AnswerA,
            AnswerB = request.AnswerB,
            AnswerC = request.AnswerC,
            AnswerD = request.AnswerD,
            CorrectAnswer = request.CorrectAnswer,
            DifficultyLevel = request.DifficultyLevel,
            IsActive = request.IsActive
        };

        await _repository.AddAsync(question);

        return new CreateQuestionResult
        {
            Success = true,
            Message = "Tạo câu hỏi thành công.",
            Data = new CreateQuestionResponse
            {
                Id = question.Id,
                Code = question.Code,
                Content = question.Content
            }
        };
    }
}
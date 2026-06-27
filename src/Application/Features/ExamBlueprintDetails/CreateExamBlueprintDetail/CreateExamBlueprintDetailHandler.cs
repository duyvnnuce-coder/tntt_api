using Domain.Entities;
using Domain.Interfaces;

namespace Application.Features.ExamBlueprintDetails.CreateExamBlueprintDetail;

public class CreateExamBlueprintDetailHandler
{
    private readonly IExamBlueprintDetailRepository _repository;
    private readonly IExamBlueprintRepository _blueprintRepository;
    private readonly IQuestionCategoryRepository _categoryRepository;

    public CreateExamBlueprintDetailHandler(
        IExamBlueprintDetailRepository repository,
        IExamBlueprintRepository blueprintRepository,
        IQuestionCategoryRepository categoryRepository)
    {
        _repository = repository;
        _blueprintRepository = blueprintRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<CreateExamBlueprintDetailResult> Handle(
        CreateExamBlueprintDetailRequest request)
    {
        var errors =
            CreateExamBlueprintDetailValidator.Validate(request);

        if (errors.Any())
        {
            return new CreateExamBlueprintDetailResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var blueprint =
            await _blueprintRepository.GetByIdAsync(
                request.ExamBlueprintId);

        if (blueprint == null)
        {
            return new CreateExamBlueprintDetailResult
            {
                Success = false,
                Message = "Exam blueprint not found."
            };
        }

        var category =
            await _categoryRepository.GetByIdAsync(
                request.QuestionCategoryId);

        if (category == null)
        {
            return new CreateExamBlueprintDetailResult
            {
                Success = false,
                Message = "Question category not found."
            };
        }

        var entity = new ExamBlueprintDetail
        {
            ExamBlueprintId = request.ExamBlueprintId,
            QuestionCategoryId = request.QuestionCategoryId,
            EasyQuestions = request.EasyQuestions,
            MediumQuestions = request.MediumQuestions,
            HardQuestions = request.HardQuestions
        };

        await _repository.AddAsync(entity);

        return new CreateExamBlueprintDetailResult
        {
            Success = true,
            Message = "Exam blueprint detail created successfully.",
            Data = new CreateExamBlueprintDetailResponse
            {
                Id = entity.Id,
                ExamBlueprintId = entity.ExamBlueprintId,
                ExamBlueprintCode = blueprint.Code,
                ExamBlueprintName = blueprint.Name,
                QuestionCategoryId = entity.QuestionCategoryId,
                QuestionCategoryCode = category.Code,
                QuestionCategoryName = category.Name,
                EasyQuestions = entity.EasyQuestions,
                MediumQuestions = entity.MediumQuestions,
                HardQuestions = entity.HardQuestions
            }
        };
    }
}
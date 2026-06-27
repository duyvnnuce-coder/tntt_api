using Domain.Interfaces;

namespace Application.Features.ExamBlueprintDetails.UpdateExamBlueprintDetail;

public class UpdateExamBlueprintDetailHandler
{
    private readonly IExamBlueprintDetailRepository _repository;
    private readonly IExamBlueprintRepository _blueprintRepository;
    private readonly IQuestionCategoryRepository _categoryRepository;

    public UpdateExamBlueprintDetailHandler(
        IExamBlueprintDetailRepository repository,
        IExamBlueprintRepository blueprintRepository,
        IQuestionCategoryRepository categoryRepository)
    {
        _repository = repository;
        _blueprintRepository = blueprintRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<UpdateExamBlueprintDetailResult> Handle(
        UpdateExamBlueprintDetailRequest request)
    {
        var errors =
            UpdateExamBlueprintDetailValidator.Validate(request);

        if (errors.Any())
        {
            return new UpdateExamBlueprintDetailResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity == null)
        {
            return new UpdateExamBlueprintDetailResult
            {
                Success = false,
                Message = "Exam blueprint detail not found."
            };
        }

        var blueprint =
            await _blueprintRepository.GetByIdAsync(
                request.ExamBlueprintId);

        if (blueprint == null)
        {
            return new UpdateExamBlueprintDetailResult
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
            return new UpdateExamBlueprintDetailResult
            {
                Success = false,
                Message = "Question category not found."
            };
        }

        entity.ExamBlueprintId = request.ExamBlueprintId;
        entity.QuestionCategoryId = request.QuestionCategoryId;
        entity.EasyQuestions = request.EasyQuestions;
        entity.MediumQuestions = request.MediumQuestions;
        entity.HardQuestions = request.HardQuestions;

        await _repository.UpdateAsync(entity);

        return new UpdateExamBlueprintDetailResult
        {
            Success = true,
            Message = "Exam blueprint detail updated successfully.",
            Data = new UpdateExamBlueprintDetailResponse
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
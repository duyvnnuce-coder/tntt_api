using Domain.Entities;
using Domain.Interfaces;

namespace Application.Features.ExamBlueprintDetails.CreateExamBlueprintDetail;

public class CreateExamBlueprintDetailHandler
{
    private readonly IExamBlueprintDetailRepository _repository;

    public CreateExamBlueprintDetailHandler(
        IExamBlueprintDetailRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateExamBlueprintDetailResult> Handle(
        CreateExamBlueprintDetailRequest request)
    {
        var validator = new CreateExamBlueprintDetailValidator();

        var errors = validator.Validate(request);

        if (errors.Any())
        {
            return new CreateExamBlueprintDetailResult
            {
                Success = false,
                Message = string.Join(" ", errors)
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
            Message = "Tạo chi tiết ma trận đề thành công.",
            Data = new CreateExamBlueprintDetailResponse
            {
                Id = entity.Id,
                ExamBlueprintId = entity.ExamBlueprintId,
                QuestionCategoryId = entity.QuestionCategoryId,
                EasyQuestions = entity.EasyQuestions,
                MediumQuestions = entity.MediumQuestions,
                HardQuestions = entity.HardQuestions
            }
        };
    }
}
using Domain.Interfaces;

namespace Application.Features.GeneratedExams.UpdateGeneratedExam;

public class UpdateGeneratedExamHandler
{
    private readonly IGeneratedExamRepository _repository;
    private readonly IExamBlueprintRepository _examBlueprintRepository;

    public UpdateGeneratedExamHandler(
        IGeneratedExamRepository repository,
        IExamBlueprintRepository examBlueprintRepository)
    {
        _repository = repository;
        _examBlueprintRepository = examBlueprintRepository;
    }

    public async Task<UpdateGeneratedExamResult> Handle(
        UpdateGeneratedExamRequest request)
    {
        var validation = UpdateGeneratedExamValidator.Validate(request);

        if (validation is not null)
        {
            return new UpdateGeneratedExamResult
            {
                Success = false,
                Message = validation
            };
        }

        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity is null)
        {
            return new UpdateGeneratedExamResult
            {
                Success = false,
                Message = "Không tìm thấy đề thi."
            };
        }

        var blueprint = await _examBlueprintRepository.GetByIdAsync(request.ExamBlueprintId);

        if (blueprint is null)
        {
            return new UpdateGeneratedExamResult
            {
                Success = false,
                Message = "Không tìm thấy đề mẫu."
            };
        }

        entity.ExamBlueprintId = request.ExamBlueprintId;
        entity.Name = request.Name;
        entity.IsPublished = request.IsPublished;

        await _repository.UpdateAsync(entity);

        return new UpdateGeneratedExamResult
        {
            Success = true,
            Message = "Cập nhật đề thi thành công.",
            Data = new UpdateGeneratedExamResponse
            {
                Id = entity.Id,
                ExamBlueprintId = entity.ExamBlueprintId,
                ExamBlueprintName = blueprint.Name,
                Code = entity.Code,
                Name = entity.Name,
                GeneratedAt = entity.GeneratedAt,
                IsPublished = entity.IsPublished
            }
        };
    }
}
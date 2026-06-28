using Domain.Interfaces;

namespace Application.Features.GeneratedExams.GetGeneratedExamById;

public class GetGeneratedExamByIdHandler
{
    private readonly IGeneratedExamRepository _repository;

    public GetGeneratedExamByIdHandler(
        IGeneratedExamRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetGeneratedExamByIdResult> Handle(
        GetGeneratedExamByIdRequest request)
    {
        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity is null)
        {
            return new GetGeneratedExamByIdResult
            {
                Success = false,
                Message = "Không tìm thấy đề thi."
            };
        }

        return new GetGeneratedExamByIdResult
        {
            Success = true,
            Message = "Lấy thông tin đề thi thành công.",
            Data = new GetGeneratedExamByIdResponse
            {
                Id = entity.Id,
                ExamBlueprintId = entity.ExamBlueprintId,
                ExamBlueprintName = entity.ExamBlueprint.Name,
                Code = entity.Code,
                Name = entity.Name,
                GeneratedAt = entity.GeneratedAt,
                IsPublished = entity.IsPublished
            }
        };
    }
}
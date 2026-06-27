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
        var errors =
            GetGeneratedExamByIdValidator.Validate(request);

        if (errors.Any())
        {
            return new GetGeneratedExamByIdResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity == null)
        {
            return new GetGeneratedExamByIdResult
            {
                Success = false,
                Message = "Generated exam not found."
            };
        }

        return new GetGeneratedExamByIdResult
        {
            Success = true,
            Message = "Success.",
            Data = new GetGeneratedExamByIdResponse
            {
                Id = entity.Id,
                ExamBlueprintId = entity.ExamBlueprintId,
                ExamBlueprintCode = entity.ExamBlueprint.Code,
                Code = entity.Code,
                Name = entity.Name,
                GeneratedAt = entity.GeneratedAt,
                IsPublished = entity.IsPublished
            }
        };
    }
}
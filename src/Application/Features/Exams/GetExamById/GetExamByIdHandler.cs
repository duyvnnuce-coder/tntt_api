using Domain.Interfaces;

namespace Application.Features.Exams.GetExamById;

public class GetExamByIdHandler
{
    private readonly IExamRepository _repository;

    public GetExamByIdHandler(
        IExamRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetExamByIdResult> Handle(
        GetExamByIdRequest request)
    {
        var errors =
            GetExamByIdValidator.Validate(request);

        if (errors.Any())
        {
            return new GetExamByIdResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity == null)
        {
            return new GetExamByIdResult
            {
                Success = false,
                Message = "Exam not found."
            };
        }

        return new GetExamByIdResult
        {
            Success = true,
            Message = "Success.",
            Data = new GetExamByIdResponse
            {
                Id = entity.Id,
                AssignmentId = entity.AssignmentId,
                AssignmentCode = entity.Assignment.Class.Code,
                Code = entity.Code,
                Name = entity.Name,
                ExamDate = entity.ExamDate,
                MaxScore = entity.MaxScore,
                IsPublished = entity.IsPublished
            }
        };
    }
}
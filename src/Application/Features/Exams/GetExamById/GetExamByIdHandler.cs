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
        var exam = await _repository.GetByIdAsync(request.Id);

        if (exam is null)
        {
            return new GetExamByIdResult
            {
                Success = false,
                Message = "Không tìm thấy kỳ thi."
            };
        }

        return new GetExamByIdResult
        {
            Success = true,
            Message = "Lấy thông tin kỳ thi thành công.",
            Data = new GetExamByIdResponse
            {
                Id = exam.Id,
                AssignmentId = exam.AssignmentId,
                AssignmentName = exam.Assignment.CatechismClass.Name,
                Code = exam.Code,
                Name = exam.Name,
                ExamDate = exam.ExamDate,
                MaxScore = exam.MaxScore,
                IsPublished = exam.IsPublished
            }
        };
    }
}
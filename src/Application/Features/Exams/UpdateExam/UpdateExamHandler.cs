using Domain.Interfaces;

namespace Application.Features.Exams.UpdateExam;

public class UpdateExamHandler
{
    private readonly IExamRepository _repository;

    public UpdateExamHandler(
        IExamRepository repository)
    {
        _repository = repository;
    }

    public async Task<UpdateExamResult> Handle(
        UpdateExamRequest request)
    {
        var exam = await _repository.GetByIdAsync(request.Id);

        if (exam is null)
        {
            return new UpdateExamResult
            {
                Success = false,
                Message = "Không tìm thấy kỳ thi."
            };
        }

        exam.AssignmentId = request.AssignmentId;
        exam.Name = request.Name;
        exam.ExamDate = request.ExamDate;
        exam.MaxScore = request.MaxScore;
        exam.IsPublished = request.IsPublished;

        await _repository.UpdateAsync(exam);

        return new UpdateExamResult
        {
            Success = true,
            Message = "Cập nhật kỳ thi thành công.",
            Data = new UpdateExamResponse
            {
                Id = exam.Id,
                Code = exam.Code
            }
        };
    }
}
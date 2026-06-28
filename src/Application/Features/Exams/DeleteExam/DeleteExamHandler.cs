using Domain.Interfaces;

namespace Application.Features.Exams.DeleteExam;

public class DeleteExamHandler
{
    private readonly IExamRepository _repository;

    public DeleteExamHandler(
        IExamRepository repository)
    {
        _repository = repository;
    }

    public async Task<DeleteExamResult> Handle(
        DeleteExamRequest request)
    {
        var exam = await _repository.GetByIdAsync(request.Id);

        if (exam is null)
        {
            return new DeleteExamResult
            {
                Success = false,
                Message = "Không tìm thấy kỳ thi."
            };
        }

        await _repository.DeleteAsync(exam);

        return new DeleteExamResult
        {
            Success = true,
            Message = "Xóa kỳ thi thành công."
        };
    }
}
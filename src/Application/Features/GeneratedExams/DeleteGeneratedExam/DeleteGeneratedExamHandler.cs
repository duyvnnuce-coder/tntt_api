using Domain.Interfaces;

namespace Application.Features.GeneratedExams.DeleteGeneratedExam;

public class DeleteGeneratedExamHandler
{
    private readonly IGeneratedExamRepository _repository;

    public DeleteGeneratedExamHandler(
        IGeneratedExamRepository repository)
    {
        _repository = repository;
    }

    public async Task<DeleteGeneratedExamResult> Handle(
        DeleteGeneratedExamRequest request)
    {
        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity is null)
        {
            return new DeleteGeneratedExamResult
            {
                Success = false,
                Message = "Không tìm thấy đề thi."
            };
        }

        await _repository.DeleteAsync(entity);

        return new DeleteGeneratedExamResult
        {
            Success = true,
            Message = "Xóa đề thi thành công."
        };
    }
}
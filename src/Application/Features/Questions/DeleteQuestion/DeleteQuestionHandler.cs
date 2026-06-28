using Domain.Interfaces;

namespace Application.Features.Questions.DeleteQuestion;

public class DeleteQuestionHandler
{
    private readonly IQuestionRepository _repository;

    public DeleteQuestionHandler(
        IQuestionRepository repository)
    {
        _repository = repository;
    }

    public async Task<DeleteQuestionResult> Handle(
        DeleteQuestionRequest request)
    {
        var question = await _repository.GetByIdAsync(request.Id);

        if (question is null)
        {
            return new DeleteQuestionResult
            {
                Success = false,
                Message = "Không tìm thấy câu hỏi."
            };
        }

        await _repository.DeleteAsync(question);

        return new DeleteQuestionResult
        {
            Success = true,
            Message = "Xóa câu hỏi thành công."
        };
    }
}
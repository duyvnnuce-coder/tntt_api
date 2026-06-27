using Domain.Interfaces;

namespace Application.Features.Assistants.DeleteAssistant;

public class DeleteAssistantHandler
{
    private readonly IAssistantRepository _repository;

    public DeleteAssistantHandler(
        IAssistantRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(Guid id)
    {
        var assistant = await _repository.GetByIdAsync(id);

        if (assistant is null)
            return;

        await _repository.DeleteAsync(assistant);
    }
}
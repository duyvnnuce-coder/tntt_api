using Application.Common.ApiResponse;
using Application.Features.Assistants.CreateAssistant;
using Application.Features.Assistants.DeleteAssistant;
using Application.Features.Assistants.GetAssistantById;
using Application.Features.Assistants.GetAssistantList;
using Application.Features.Assistants.UpdateAssistant;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/assistants")]
public class AssistantsController : ControllerBase
{
    private readonly CreateAssistantHandler _createHandler;
    private readonly GetAssistantByIdHandler _getByIdHandler;
    private readonly GetAssistantListHandler _getListHandler;
    private readonly UpdateAssistantHandler _updateHandler;
    private readonly DeleteAssistantHandler _deleteHandler;

    public AssistantsController(
        CreateAssistantHandler createHandler,
        GetAssistantByIdHandler getByIdHandler,
        GetAssistantListHandler getListHandler,
        UpdateAssistantHandler updateHandler,
        DeleteAssistantHandler deleteHandler)
    {
        _createHandler = createHandler;
        _getByIdHandler = getByIdHandler;
        _getListHandler = getListHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAssistantRequest request)
    {
        return Ok(await _createHandler.Handle(request));
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        return Ok(ApiResponse<object>.Ok(
            await _getListHandler.Handle()));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _getByIdHandler.Handle(
            new GetAssistantByIdRequest
            {
                Id = id
            }));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateAssistantRequest request)
    {
        request.Id = id;

        return Ok(await _updateHandler.Handle(request));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _deleteHandler.Handle(id);

        return Ok(ApiResponse<string>.Ok("Deleted"));
    }
}
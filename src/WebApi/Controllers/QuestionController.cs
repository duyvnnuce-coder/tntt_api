using Application.Features.Questions.CreateQuestion;
using Application.Features.Questions.DeleteQuestion;
using Application.Features.Questions.GetQuestionById;
using Application.Features.Questions.GetQuestionList;
using Application.Features.Questions.UpdateQuestion;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/questions")]
public class QuestionsController : ControllerBase
{
    private readonly CreateQuestionHandler _createHandler;
    private readonly GetQuestionListHandler _listHandler;
    private readonly GetQuestionByIdHandler _byIdHandler;
    private readonly UpdateQuestionHandler _updateHandler;
    private readonly DeleteQuestionHandler _deleteHandler;

    public QuestionsController(
        CreateQuestionHandler createHandler,
        GetQuestionListHandler listHandler,
        GetQuestionByIdHandler byIdHandler,
        UpdateQuestionHandler updateHandler,
        DeleteQuestionHandler deleteHandler)
    {
        _createHandler = createHandler;
        _listHandler = listHandler;
        _byIdHandler = byIdHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        return Ok(await _listHandler.Handle(
            new GetQuestionListRequest()));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _byIdHandler.Handle(
            new GetQuestionByIdRequest
            {
                Id = id
            }));
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateQuestionRequest request)
    {
        return Ok(await _createHandler.Handle(request));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateQuestionRequest request)
    {
        request.Id = id;

        return Ok(await _updateHandler.Handle(request));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await _deleteHandler.Handle(
            new DeleteQuestionRequest
            {
                Id = id
            }));
    }
}
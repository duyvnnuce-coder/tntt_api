using Application.Features.Questions.CreateQuestion;
using Application.Features.Questions.GetQuestionById;
using Application.Features.Questions.GetQuestionList;
using Application.Features.Questions.UpdateQuestion;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/questions")]
public class QuestionController : ControllerBase
{
    private readonly CreateQuestionHandler _createHandler;
    private readonly GetQuestionByIdHandler _getByIdHandler;
    private readonly GetQuestionListHandler _getListHandler;
    private readonly UpdateQuestionHandler _updateHandler;

    public QuestionController(
        CreateQuestionHandler createHandler,
        GetQuestionByIdHandler getByIdHandler,
        GetQuestionListHandler getListHandler,
        UpdateQuestionHandler updateHandler)
    {
        _createHandler = createHandler;
        _getByIdHandler = getByIdHandler;
        _getListHandler = getListHandler;
        _updateHandler = updateHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateQuestionRequest request)
    {
        var result = await _createHandler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _getByIdHandler.Handle(
            new GetQuestionByIdRequest
            {
                Id = id
            });

        if (!result.Success)
            return NotFound(result);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetQuestionListRequest request)
    {
        var result = await _getListHandler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(
        UpdateQuestionRequest request)
    {
        var result = await _updateHandler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}
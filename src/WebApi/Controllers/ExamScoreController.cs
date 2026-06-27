using Application.Features.ExamScores.CreateExamScore;
using Application.Features.ExamScores.GetExamScoreById;
using Application.Features.ExamScores.GetExamScoreList;
using Application.Features.ExamScores.UpdateExamScore;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/exam-scores")]
public class ExamScoreController : ControllerBase
{
    private readonly CreateExamScoreHandler _createHandler;
    private readonly GetExamScoreByIdHandler _getByIdHandler;
    private readonly GetExamScoreListHandler _getListHandler;
    private readonly UpdateExamScoreHandler _updateHandler;

    public ExamScoreController(
        CreateExamScoreHandler createHandler,
        GetExamScoreByIdHandler getByIdHandler,
        GetExamScoreListHandler getListHandler,
        UpdateExamScoreHandler updateHandler)
    {
        _createHandler = createHandler;
        _getByIdHandler = getByIdHandler;
        _getListHandler = getListHandler;
        _updateHandler = updateHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateExamScoreRequest request)
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
            new GetExamScoreByIdRequest
            {
                Id = id
            });

        if (!result.Success)
            return NotFound(result);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetExamScoreListRequest request)
    {
        var result = await _getListHandler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(
        UpdateExamScoreRequest request)
    {
        var result = await _updateHandler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}
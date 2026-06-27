using Application.Features.Exams.CreateExam;
using Application.Features.Exams.GetExamById;
using Application.Features.Exams.GetExamList;
using Application.Features.Exams.UpdateExam;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/exams")]
public class ExamController : ControllerBase
{
    private readonly CreateExamHandler _createHandler;
    private readonly GetExamByIdHandler _getByIdHandler;
    private readonly GetExamListHandler _getListHandler;
    private readonly UpdateExamHandler _updateHandler;

    public ExamController(
        CreateExamHandler createHandler,
        GetExamByIdHandler getByIdHandler,
        GetExamListHandler getListHandler,
        UpdateExamHandler updateHandler)
    {
        _createHandler = createHandler;
        _getByIdHandler = getByIdHandler;
        _getListHandler = getListHandler;
        _updateHandler = updateHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateExamRequest request)
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
            new GetExamByIdRequest
            {
                Id = id
            });

        if (!result.Success)
            return NotFound(result);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetExamListRequest request)
    {
        var result = await _getListHandler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(
        UpdateExamRequest request)
    {
        var result = await _updateHandler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}
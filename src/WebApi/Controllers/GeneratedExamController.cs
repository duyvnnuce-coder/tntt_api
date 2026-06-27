using Application.Features.GeneratedExams.CreateGeneratedExam;
using Application.Features.GeneratedExams.GetGeneratedExamById;
using Application.Features.GeneratedExams.GetGeneratedExamList;
using Application.Features.GeneratedExams.UpdateGeneratedExam;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/generated-exams")]
public class GeneratedExamController : ControllerBase
{
    private readonly CreateGeneratedExamHandler _createHandler;
    private readonly GetGeneratedExamByIdHandler _getByIdHandler;
    private readonly GetGeneratedExamListHandler _getListHandler;
    private readonly UpdateGeneratedExamHandler _updateHandler;

    public GeneratedExamController(
        CreateGeneratedExamHandler createHandler,
        GetGeneratedExamByIdHandler getByIdHandler,
        GetGeneratedExamListHandler getListHandler,
        UpdateGeneratedExamHandler updateHandler)
    {
        _createHandler = createHandler;
        _getByIdHandler = getByIdHandler;
        _getListHandler = getListHandler;
        _updateHandler = updateHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateGeneratedExamRequest request)
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
            new GetGeneratedExamByIdRequest
            {
                Id = id
            });

        if (!result.Success)
            return NotFound(result);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetGeneratedExamListRequest request)
    {
        var result = await _getListHandler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(
        UpdateGeneratedExamRequest request)
    {
        var result = await _updateHandler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}
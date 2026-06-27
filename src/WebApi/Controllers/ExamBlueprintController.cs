using Application.Features.ExamBlueprints.CreateExamBlueprint;
using Application.Features.ExamBlueprints.GetExamBlueprintById;
using Application.Features.ExamBlueprints.GetExamBlueprintList;
using Application.Features.ExamBlueprints.UpdateExamBlueprint;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/exam-blueprints")]
public class ExamBlueprintController : ControllerBase
{
    private readonly CreateExamBlueprintHandler _createHandler;
    private readonly GetExamBlueprintByIdHandler _getByIdHandler;
    private readonly GetExamBlueprintListHandler _getListHandler;
    private readonly UpdateExamBlueprintHandler _updateHandler;

    public ExamBlueprintController(
        CreateExamBlueprintHandler createHandler,
        GetExamBlueprintByIdHandler getByIdHandler,
        GetExamBlueprintListHandler getListHandler,
        UpdateExamBlueprintHandler updateHandler)
    {
        _createHandler = createHandler;
        _getByIdHandler = getByIdHandler;
        _getListHandler = getListHandler;
        _updateHandler = updateHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateExamBlueprintRequest request)
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
            new GetExamBlueprintByIdRequest
            {
                Id = id
            });

        if (!result.Success)
            return NotFound(result);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetExamBlueprintListRequest request)
    {
        var result = await _getListHandler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(
        UpdateExamBlueprintRequest request)
    {
        var result = await _updateHandler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}
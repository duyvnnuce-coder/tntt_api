using Application.Features.ExamBlueprintDetails.CreateExamBlueprintDetail;
using Application.Features.ExamBlueprintDetails.DeleteExamBlueprintDetail;
using Application.Features.ExamBlueprintDetails.GetExamBlueprintDetailById;
using Application.Features.ExamBlueprintDetails.GetExamBlueprintDetailList;
using Application.Features.ExamBlueprintDetails.UpdateExamBlueprintDetail;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/exam-blueprint-details")]
public class ExamBlueprintDetailController : ControllerBase
{
    private readonly CreateExamBlueprintDetailHandler _createHandler;
    private readonly GetExamBlueprintDetailByIdHandler _getByIdHandler;
    private readonly GetExamBlueprintDetailListHandler _getListHandler;
    private readonly UpdateExamBlueprintDetailHandler _updateHandler;
    private readonly DeleteExamBlueprintDetailHandler _deleteHandler;

    public ExamBlueprintDetailController(
        CreateExamBlueprintDetailHandler createHandler,
        GetExamBlueprintDetailByIdHandler getByIdHandler,
        GetExamBlueprintDetailListHandler getListHandler,
        UpdateExamBlueprintDetailHandler updateHandler,
        DeleteExamBlueprintDetailHandler deleteHandler)
    {
        _createHandler = createHandler;
        _getByIdHandler = getByIdHandler;
        _getListHandler = getListHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateExamBlueprintDetailRequest request)
    {
        var result = await _createHandler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetExamBlueprintDetailListRequest request)
    {
        var result = await _getListHandler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _getByIdHandler.Handle(
            new GetExamBlueprintDetailByIdRequest
            {
                Id = id
            });

        if (!result.Success)
            return NotFound(result);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(
        UpdateExamBlueprintDetailRequest request)
    {
        var result = await _updateHandler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _deleteHandler.Handle(
            new DeleteExamBlueprintDetailRequest
            {
                Id = id
            });

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}
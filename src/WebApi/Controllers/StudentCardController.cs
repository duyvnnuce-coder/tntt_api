using Application.Features.StudentCards.CreateStudentCard;
using Application.Features.StudentCards.GetStudentCardList;
using Application.Features.StudentCards.GetStudentCardByStudentId;
using Application.Features.StudentCards.UpdateStudentCardStatus;
using Application.Features.StudentCards.ReissueStudentCard;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/student-cards")]
public class StudentCardController : ControllerBase
{
    private readonly CreateStudentCardHandler _createHandler;
    private readonly GetStudentCardListHandler _getListHandler;
    private readonly GetStudentCardByStudentIdHandler _getByStudentHandler;
    private readonly UpdateStudentCardStatusHandler _updateStatusHandler;
    private readonly ReissueStudentCardHandler _reissueHandler;

    public StudentCardController(
        CreateStudentCardHandler createHandler,
        GetStudentCardListHandler getListHandler,
        GetStudentCardByStudentIdHandler getByStudentHandler,
        UpdateStudentCardStatusHandler updateStatusHandler,
        ReissueStudentCardHandler reissueHandler)
    {
        _createHandler = createHandler;
        _getListHandler = getListHandler;
        _getByStudentHandler = getByStudentHandler;
        _updateStatusHandler = updateStatusHandler;
        _reissueHandler = reissueHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateStudentCardRequest request)
    {
        var result = await _createHandler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetStudentCardListRequest request)
    {
        var result = await _getListHandler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("student/{studentId:guid}")]
    public async Task<IActionResult> GetByStudent(Guid studentId)
    {
        var result = await _getByStudentHandler.Handle(
            new GetStudentCardByStudentIdRequest
            {
                StudentId = studentId
            });

        if (!result.Success)
            return NotFound(result);

        return Ok(result);
    }

    [HttpPut("status")]
    public async Task<IActionResult> UpdateStatus(
        UpdateStudentCardStatusRequest request)
    {
        var result = await _updateStatusHandler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("reissue")]
    public async Task<IActionResult> Reissue(
        ReissueStudentCardRequest request)
    {
        var result = await _reissueHandler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}
using Application.Features.AttendanceSessions.CreateAttendanceSession;
using Application.Features.AttendanceSessions.DeleteAttendanceSession;
using Application.Features.AttendanceSessions.GetAttendanceSessionById;
using Application.Features.AttendanceSessions.GetAttendanceSessionList;
using Application.Features.AttendanceSessions.UpdateAttendanceSession;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/attendance-sessions")]
public class AttendanceSessionsController : ControllerBase
{
    private readonly CreateAttendanceSessionHandler _createHandler;
    private readonly GetAttendanceSessionListHandler _listHandler;
    private readonly GetAttendanceSessionByIdHandler _byIdHandler;
    private readonly UpdateAttendanceSessionHandler _updateHandler;
    private readonly DeleteAttendanceSessionHandler _deleteHandler;

    public AttendanceSessionsController(
        CreateAttendanceSessionHandler createHandler,
        GetAttendanceSessionListHandler listHandler,
        GetAttendanceSessionByIdHandler byIdHandler,
        UpdateAttendanceSessionHandler updateHandler,
        DeleteAttendanceSessionHandler deleteHandler)
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
            new GetAttendanceSessionListRequest()));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _byIdHandler.Handle(
            new GetAttendanceSessionByIdRequest
            {
                Id = id
            }));
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateAttendanceSessionRequest request)
    {
        return Ok(await _createHandler.Handle(request));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateAttendanceSessionRequest request)
    {
        request.Id = id;

        return Ok(await _updateHandler.Handle(request));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await _deleteHandler.Handle(
            new DeleteAttendanceSessionRequest
            {
                Id = id
            }));
    }
}
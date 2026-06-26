using Application.Features.AttendanceSessions.CreateAttendanceSession;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/attendance-sessions")]
public class AttendanceSessionController : ControllerBase
{
    private readonly CreateAttendanceSessionHandler _handler;

    public AttendanceSessionController(
        CreateAttendanceSessionHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateAttendanceSessionRequest request)
    {
        var result = await _handler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}
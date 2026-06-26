using Application.Features.Attendances.CreateAttendance;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/attendances")]
public class AttendanceController : ControllerBase
{
    private readonly CreateAttendanceHandler _createHandler;

    public AttendanceController(
        CreateAttendanceHandler createHandler)
    {
        _createHandler = createHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAttendanceRequest request)
    {
        var result = await _createHandler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}
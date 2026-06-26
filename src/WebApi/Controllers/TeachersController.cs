using Application.Features.Teachers.CreateTeacher;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/teachers")]
public class TeachersController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] CreateTeacherHandler handler,
        [FromBody] CreateTeacherRequest request)
    {
        var result = await handler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}
using Application.Features.Semesters.CreateSemester;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/semesters")]
public class SemestersController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] CreateSemesterHandler handler,
        [FromBody] CreateSemesterRequest request)
    {
        var result = await handler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}
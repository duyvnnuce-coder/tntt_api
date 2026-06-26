using Application.Features.CatechismClasses.CreateCatechismClass;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/catechism-classes")]
public class CatechismClassesController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] CreateCatechismClassHandler handler,
        [FromBody] CreateCatechismClassRequest request)
    {
        var result = await handler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}
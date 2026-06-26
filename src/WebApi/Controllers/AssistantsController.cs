using Application.Features.Assistants.CreateAssistant;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/assistants")]
public class AssistantsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] CreateAssistantHandler handler,
        [FromBody] CreateAssistantRequest request)
    {
        var result = await handler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}
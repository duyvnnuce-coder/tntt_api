using Application.Features.Parishes.CreateParish;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/parishes")]
public class ParishesController : ControllerBase
{
    private readonly CreateParishHandler _handler;

    public ParishesController(CreateParishHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateParishCommand request)
    {
        var result = await _handler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}
using Application.Features.Sacraments.CreateSacrament;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/sacraments")]
public class SacramentController : ControllerBase
{
    private readonly CreateSacramentHandler _createHandler;

    public SacramentController(
        CreateSacramentHandler createHandler)
    {
        _createHandler = createHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSacramentRequest request)
    {
        var result = await _createHandler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}
using Application.Features.Sacraments.CreateSacrament;
using Application.Features.Sacraments.GetSacramentById;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/sacraments")]
public class SacramentController : ControllerBase
{
    private readonly CreateSacramentHandler _createHandler;
    private readonly GetSacramentByIdHandler _getByIdHandler;

    public SacramentController(
        CreateSacramentHandler createHandler,
        GetSacramentByIdHandler getByIdHandler)
    {
        _createHandler = createHandler;
        _getByIdHandler = getByIdHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSacramentRequest request)
    {
        var result = await _createHandler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _getByIdHandler.Handle(
            new GetSacramentByIdRequest
            {
                Id = id
            });

        if (!result.Success)
            return NotFound(result);

        return Ok(result);
    }
}
using Application.Features.Sacraments.CreateSacrament;
using Application.Features.Sacraments.GetSacramentById;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Sacraments.GetSacramentList;

namespace WebApi.Controllers;

[ApiController]
[Route("api/sacraments")]
public class SacramentController : ControllerBase
{
    private readonly CreateSacramentHandler _createHandler;
    private readonly GetSacramentByIdHandler _getByIdHandler;
    private readonly GetSacramentListHandler _getListHandler;

    public SacramentController(
        CreateSacramentHandler createHandler,
        GetSacramentByIdHandler getByIdHandler,
        GetSacramentListHandler getListHandler)
    {
        _createHandler = createHandler;
        _getByIdHandler = getByIdHandler;
        _getListHandler = getListHandler;
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

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetSacramentListRequest request)
    {
        var result = await _getListHandler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}
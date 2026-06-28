using Application.Common.ApiResponse;
using Application.Features.Parishes.CreateParish;
using Application.Features.Parishes.DeleteParish;
using Application.Features.Parishes.GetParishById;
using Application.Features.Parishes.GetParishList;
using Application.Features.Parishes.UpdateParish;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/parishes")]
public class ParishesController : ControllerBase
{
    private readonly CreateParishHandler _createHandler;
    private readonly GetParishByIdHandler _getByIdHandler;
    private readonly GetParishListHandler _getListHandler;
    private readonly UpdateParishHandler _updateHandler;
    private readonly DeleteParishHandler _deleteHandler;

    public ParishesController(
        CreateParishHandler createHandler,
        GetParishByIdHandler getByIdHandler,
        GetParishListHandler getListHandler,
        UpdateParishHandler updateHandler,
        DeleteParishHandler deleteHandler)
    {
        _createHandler = createHandler;
        _getByIdHandler = getByIdHandler;
        _getListHandler = getListHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateParishRequest request)
    {
        return Ok(await _createHandler.Handle(request));
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        return Ok(ApiResponse<object>.Ok(
            await _getListHandler.Handle()));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _getByIdHandler.Handle(
            new GetParishByIdRequest
            {
                Id = id
            }));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateParishRequest request)
    {
        request.Id = id;

        await _updateHandler.Handle(request);

        return Ok(ApiResponse<string>.Ok("Updated"));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _deleteHandler.Handle(id);

        return Ok(ApiResponse<string>.Ok("Deleted"));
    }
}
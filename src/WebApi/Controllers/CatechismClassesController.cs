using Application.Features.CatechismClasses.CreateCatechismClass;
using Application.Features.CatechismClasses.DeleteCatechismClass;
using Application.Features.CatechismClasses.GetCatechismClassById;
using Application.Features.CatechismClasses.GetCatechismClassList;
using Application.Features.CatechismClasses.UpdateCatechismClass;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/catechism-classes")]
public class CatechismClassesController : ControllerBase
{
    private readonly CreateCatechismClassHandler _createHandler;
    private readonly GetCatechismClassListHandler _listHandler;
    private readonly GetCatechismClassByIdHandler _byIdHandler;
    private readonly UpdateCatechismClassHandler _updateHandler;
    private readonly DeleteCatechismClassHandler _deleteHandler;

    public CatechismClassesController(
        CreateCatechismClassHandler createHandler,
        GetCatechismClassListHandler listHandler,
        GetCatechismClassByIdHandler byIdHandler,
        UpdateCatechismClassHandler updateHandler,
        DeleteCatechismClassHandler deleteHandler)
    {
        _createHandler = createHandler;
        _listHandler = listHandler;
        _byIdHandler = byIdHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        return Ok(await _listHandler.Handle(
            new GetCatechismClassListRequest()));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _byIdHandler.Handle(
            new GetCatechismClassByIdRequest
            {
                Id = id
            }));
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateCatechismClassRequest request)
    {
        return Ok(await _createHandler.Handle(request));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateCatechismClassRequest request)
    {
        request.Id = id;

        return Ok(await _updateHandler.Handle(request));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await _deleteHandler.Handle(
            new DeleteCatechismClassRequest
            {
                Id = id
            }));
    }
}
using Application.Features.CatechismGrades.CreateCatechismGrade;
using Application.Features.CatechismGrades.DeleteCatechismGrade;
using Application.Features.CatechismGrades.GetCatechismGradeById;
using Application.Features.CatechismGrades.GetCatechismGradeList;
using Application.Features.CatechismGrades.UpdateCatechismGrade;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/catechism-grades")]
public class CatechismGradesController : ControllerBase
{
    private readonly CreateCatechismGradeHandler _createHandler;
    private readonly GetCatechismGradeListHandler _listHandler;
    private readonly GetCatechismGradeByIdHandler _byIdHandler;
    private readonly UpdateCatechismGradeHandler _updateHandler;
    private readonly DeleteCatechismGradeHandler _deleteHandler;

    public CatechismGradesController(
        CreateCatechismGradeHandler createHandler,
        GetCatechismGradeListHandler listHandler,
        GetCatechismGradeByIdHandler byIdHandler,
        UpdateCatechismGradeHandler updateHandler,
        DeleteCatechismGradeHandler deleteHandler)
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
        return Ok(await _listHandler.Handle(new GetCatechismGradeListRequest()));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _byIdHandler.Handle(
            new GetCatechismGradeByIdRequest
            {
                Id = id
            }));
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateCatechismGradeRequest request)
    {
        return Ok(await _createHandler.Handle(request));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateCatechismGradeRequest request)
    {
        request.Id = id;

        return Ok(await _updateHandler.Handle(request));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await _deleteHandler.Handle(
            new DeleteCatechismGradeRequest
            {
                Id = id
            }));
    }
}
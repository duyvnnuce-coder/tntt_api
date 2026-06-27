using Application.Common.ApiResponse;
using Application.Features.Teachers.CreateTeacher;
using Application.Features.Teachers.DeleteTeacher;
using Application.Features.Teachers.GetTeacherById;
using Application.Features.Teachers.GetTeacherList;
using Application.Features.Teachers.UpdateTeacher;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/teachers")]
public class TeachersController : ControllerBase
{
    private readonly CreateTeacherHandler _createHandler;
    private readonly GetTeacherByIdHandler _getByIdHandler;
    private readonly GetTeacherListHandler _getListHandler;
    private readonly UpdateTeacherHandler _updateHandler;
    private readonly DeleteTeacherHandler _deleteHandler;

    public TeachersController(
        CreateTeacherHandler createHandler,
        GetTeacherByIdHandler getByIdHandler,
        GetTeacherListHandler getListHandler,
        UpdateTeacherHandler updateHandler,
        DeleteTeacherHandler deleteHandler)
    {
        _createHandler = createHandler;
        _getByIdHandler = getByIdHandler;
        _getListHandler = getListHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTeacherRequest request)
    {
        return Ok(await _createHandler.Handle(request));
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        return Ok(ApiResponse<object>.Ok(await _getListHandler.Handle()));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _getByIdHandler.Handle(
            new GetTeacherByIdRequest
            {
                Id = id
            }));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateTeacherRequest request)
    {
        request.Id = id;

        return Ok(await _updateHandler.Handle(request));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _deleteHandler.Handle(id);

        return Ok(ApiResponse<string>.Ok("Deleted"));
    }
}
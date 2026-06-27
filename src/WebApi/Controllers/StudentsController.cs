using Application.Common.ApiResponse;
using Application.Features.Students.CreateStudent;
using Application.Features.Students.DeleteStudent;
using Application.Features.Students.GetStudentById;
using Application.Features.Students.GetStudentList;
using Application.Features.Students.UpdateStudent;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/students")]
public class StudentsController : ControllerBase
{
    private readonly CreateStudentHandler _createHandler;
    private readonly GetStudentByIdHandler _getByIdHandler;
    private readonly GetStudentListHandler _getListHandler;
    private readonly UpdateStudentHandler _updateHandler;
    private readonly DeleteStudentHandler _deleteHandler;

    public StudentsController(
        CreateStudentHandler createHandler,
        GetStudentByIdHandler getByIdHandler,
        GetStudentListHandler getListHandler,
        UpdateStudentHandler updateHandler,
        DeleteStudentHandler deleteHandler)
    {
        _createHandler = createHandler;
        _getByIdHandler = getByIdHandler;
        _getListHandler = getListHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateStudentRequest request)
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
                      new GetStudentByIdRequest
                      {
                          Id = id
                      }));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateStudentRequest request)
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
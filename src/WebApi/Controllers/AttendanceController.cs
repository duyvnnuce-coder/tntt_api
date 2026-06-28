using Application.Features.Attendances.CreateAttendance;
using Application.Features.Attendances.DeleteAttendance;
using Application.Features.Attendances.GetAttendanceById;
using Application.Features.Attendances.GetAttendanceList;
using Application.Features.Attendances.UpdateAttendance;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/attendances")]
public class AttendancesController : ControllerBase
{
    private readonly CreateAttendanceHandler _createHandler;
    private readonly GetAttendanceListHandler _listHandler;
    private readonly GetAttendanceByIdHandler _byIdHandler;
    private readonly UpdateAttendanceHandler _updateHandler;
    private readonly DeleteAttendanceHandler _deleteHandler;

    public AttendancesController(
        CreateAttendanceHandler createHandler,
        GetAttendanceListHandler listHandler,
        GetAttendanceByIdHandler byIdHandler,
        UpdateAttendanceHandler updateHandler,
        DeleteAttendanceHandler deleteHandler)
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
            new GetAttendanceListRequest()));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _byIdHandler.Handle(
            new GetAttendanceByIdRequest
            {
                Id = id
            }));
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateAttendanceRequest request)
    {
        return Ok(await _createHandler.Handle(request));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateAttendanceRequest request)
    {
        request.Id = id;

        return Ok(await _updateHandler.Handle(request));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await _deleteHandler.Handle(
            new DeleteAttendanceRequest
            {
                Id = id
            }));
    }
}
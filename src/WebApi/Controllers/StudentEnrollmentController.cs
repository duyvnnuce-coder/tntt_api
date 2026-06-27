using Application.Features.StudentEnrollments.CreateStudentEnrollment;
using Application.Features.StudentEnrollments.GetStudentEnrollmentById;
using Application.Features.StudentEnrollments.GetStudentEnrollmentList;
using Application.Features.StudentEnrollments.UpdateStudentEnrollment;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/student-enrollments")]
public class StudentEnrollmentController : ControllerBase
{
    private readonly CreateStudentEnrollmentHandler _createHandler;
    private readonly GetStudentEnrollmentByIdHandler _getByIdHandler;
    private readonly GetStudentEnrollmentListHandler _getListHandler;
    private readonly UpdateStudentEnrollmentHandler _updateHandler;

    public StudentEnrollmentController(
        CreateStudentEnrollmentHandler createHandler,
        GetStudentEnrollmentByIdHandler getByIdHandler,
        GetStudentEnrollmentListHandler getListHandler,
        UpdateStudentEnrollmentHandler updateHandler)
    {
        _createHandler = createHandler;
        _getByIdHandler = getByIdHandler;
        _getListHandler = getListHandler;
        _updateHandler = updateHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateStudentEnrollmentRequest request)
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
            new GetStudentEnrollmentByIdRequest
            {
                Id = id
            });

        if (!result.Success)
            return NotFound(result);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetStudentEnrollmentListRequest request)
    {
        var result = await _getListHandler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(
        UpdateStudentEnrollmentRequest request)
    {
        var result = await _updateHandler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}
using Application.Features.StudentEnrollments.CreateStudentEnrollment;
using Application.Features.StudentEnrollments.DeleteStudentEnrollment;
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
    private readonly DeleteStudentEnrollmentHandler _deleteHandler;

    public StudentEnrollmentController(
        CreateStudentEnrollmentHandler createHandler,
        GetStudentEnrollmentByIdHandler getByIdHandler,
        GetStudentEnrollmentListHandler getListHandler,
        UpdateStudentEnrollmentHandler updateHandler,
        DeleteStudentEnrollmentHandler deleteHandler)
    {
        _createHandler = createHandler;
        _getByIdHandler = getByIdHandler;
        _getListHandler = getListHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateStudentEnrollmentRequest request)
    {
        return Ok(await _createHandler.Handle(request));
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        return Ok(await _getListHandler.Handle(
            new GetStudentEnrollmentListRequest()));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _getByIdHandler.Handle(
            new GetStudentEnrollmentByIdRequest
            {
                Id = id
            }));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateStudentEnrollmentRequest request)
    {
        request.Id = id;

        return Ok(await _updateHandler.Handle(request));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await _deleteHandler.Handle(
            new DeleteStudentEnrollmentRequest
            {
                Id = id
            }));
    }
}
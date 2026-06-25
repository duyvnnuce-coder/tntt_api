using Application.Features.Students.CreateStudent;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/students")]
public class StudentsController : ControllerBase
{
    private readonly CreateStudentHandler _handler;

    public StudentsController(CreateStudentHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateStudentRequest request)
    {
        var result = await _handler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}
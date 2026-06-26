using Application.Features.Assignments.CreateAssignment;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/assignments")]
public class AssignmentsController : ControllerBase
{
    private readonly CreateAssignmentHandler _handler;

    public AssignmentsController(CreateAssignmentHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateAssignmentRequest request)
    {
        var result = await _handler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}
using Application.Features.AcademicYears.CreateAcademicYear;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/academic-years")]
public class AcademicYearsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] CreateAcademicYearHandler handler,
        [FromBody] CreateAcademicYearRequest request)
    {
        var result = await handler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}
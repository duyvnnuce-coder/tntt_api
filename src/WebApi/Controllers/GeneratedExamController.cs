using Application.Features.GeneratedExams.CreateGeneratedExam;
using Application.Features.GeneratedExams.DeleteGeneratedExam;
using Application.Features.GeneratedExams.GetGeneratedExamById;
using Application.Features.GeneratedExams.GetGeneratedExamList;
using Application.Features.GeneratedExams.UpdateGeneratedExam;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/generated-exams")]
public class GeneratedExamController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] CreateGeneratedExamHandler handler,
        CreateGeneratedExamRequest request)
    {
        return Ok(await handler.Handle(request));
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromServices] GetGeneratedExamListHandler handler)
    {
        return Ok(await handler.Handle(new GetGeneratedExamListRequest()));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(
        [FromServices] GetGeneratedExamByIdHandler handler,
        Guid id)
    {
        return Ok(await handler.Handle(new GetGeneratedExamByIdRequest
        {
            Id = id
        }));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        [FromServices] UpdateGeneratedExamHandler handler,
        Guid id,
        UpdateGeneratedExamRequest request)
    {
        request.Id = id;

        return Ok(await handler.Handle(request));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(
        [FromServices] DeleteGeneratedExamHandler handler,
        Guid id)
    {
        return Ok(await handler.Handle(new DeleteGeneratedExamRequest
        {
            Id = id
        }));
    }
}
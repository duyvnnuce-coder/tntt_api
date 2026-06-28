using Application.Features.Exams.CreateExam;
using Application.Features.Exams.DeleteExam;
using Application.Features.Exams.GetExamById;
using Application.Features.Exams.GetExamList;
using Application.Features.Exams.UpdateExam;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/exams")]
public class ExamController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] CreateExamHandler handler,
        CreateExamRequest request)
    {
        return Ok(await handler.Handle(request));
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromServices] GetExamListHandler handler)
    {
        return Ok(await handler.Handle(new GetExamListRequest()));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(
        [FromServices] GetExamByIdHandler handler,
        Guid id)
    {
        return Ok(await handler.Handle(new GetExamByIdRequest
        {
            Id = id
        }));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        [FromServices] UpdateExamHandler handler,
        Guid id,
        UpdateExamRequest request)
    {
        request.Id = id;
        return Ok(await handler.Handle(request));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(
        [FromServices] DeleteExamHandler handler,
        Guid id)
    {
        return Ok(await handler.Handle(new DeleteExamRequest
        {
            Id = id
        }));
    }
}
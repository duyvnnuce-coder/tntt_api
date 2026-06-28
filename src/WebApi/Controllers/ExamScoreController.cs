using Application.Features.ExamScores.CreateExamScore;
using Application.Features.ExamScores.DeleteExamScore;
using Application.Features.ExamScores.GetExamScoreById;
using Application.Features.ExamScores.GetExamScoreList;
using Application.Features.ExamScores.UpdateExamScore;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/exam-scores")]
public class ExamScoreController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] CreateExamScoreHandler handler,
        CreateExamScoreRequest request)
    {
        return Ok(await handler.Handle(request));
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromServices] GetExamScoreListHandler handler)
    {
        return Ok(await handler.Handle(new GetExamScoreListRequest()));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(
        [FromServices] GetExamScoreByIdHandler handler,
        Guid id)
    {
        return Ok(await handler.Handle(new GetExamScoreByIdRequest
        {
            Id = id
        }));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        [FromServices] UpdateExamScoreHandler handler,
        Guid id,
        UpdateExamScoreRequest request)
    {
        request.Id = id;
        return Ok(await handler.Handle(request));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(
        [FromServices] DeleteExamScoreHandler handler,
        Guid id)
    {
        return Ok(await handler.Handle(new DeleteExamScoreRequest
        {
            Id = id
        }));
    }
}
using Application.Features.QuestionCategories.CreateQuestionCategory;
using Application.Features.QuestionCategories.GetQuestionCategoryById;
using Application.Features.QuestionCategories.GetQuestionCategoryList;
using Application.Features.QuestionCategories.UpdateQuestionCategory;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/question-categories")]
public class QuestionCategoryController : ControllerBase
{
    private readonly CreateQuestionCategoryHandler _createHandler;
    private readonly GetQuestionCategoryByIdHandler _getByIdHandler;
    private readonly GetQuestionCategoryListHandler _getListHandler;
    private readonly UpdateQuestionCategoryHandler _updateHandler;

    public QuestionCategoryController(
        CreateQuestionCategoryHandler createHandler,
        GetQuestionCategoryByIdHandler getByIdHandler,
        GetQuestionCategoryListHandler getListHandler,
        UpdateQuestionCategoryHandler updateHandler)
    {
        _createHandler = createHandler;
        _getByIdHandler = getByIdHandler;
        _getListHandler = getListHandler;
        _updateHandler = updateHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateQuestionCategoryRequest request)
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
            new GetQuestionCategoryByIdRequest
            {
                Id = id
            });

        if (!result.Success)
            return NotFound(result);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetQuestionCategoryListRequest request)
    {
        var result = await _getListHandler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(
        UpdateQuestionCategoryRequest request)
    {
        var result = await _updateHandler.Handle(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}
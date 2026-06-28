using Application.Features.QuestionCategories.CreateQuestionCategory;
using Application.Features.QuestionCategories.DeleteQuestionCategory;
using Application.Features.QuestionCategories.GetQuestionCategoryById;
using Application.Features.QuestionCategories.GetQuestionCategoryList;
using Application.Features.QuestionCategories.UpdateQuestionCategory;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/question-categories")]
public class QuestionCategoriesController : ControllerBase
{
    private readonly CreateQuestionCategoryHandler _createHandler;
    private readonly GetQuestionCategoryListHandler _listHandler;
    private readonly GetQuestionCategoryByIdHandler _byIdHandler;
    private readonly UpdateQuestionCategoryHandler _updateHandler;
    private readonly DeleteQuestionCategoryHandler _deleteHandler;

    public QuestionCategoriesController(
        CreateQuestionCategoryHandler createHandler,
        GetQuestionCategoryListHandler listHandler,
        GetQuestionCategoryByIdHandler byIdHandler,
        UpdateQuestionCategoryHandler updateHandler,
        DeleteQuestionCategoryHandler deleteHandler)
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
            new GetQuestionCategoryListRequest()));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _byIdHandler.Handle(
            new GetQuestionCategoryByIdRequest
            {
                Id = id
            }));
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateQuestionCategoryRequest request)
    {
        return Ok(await _createHandler.Handle(request));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateQuestionCategoryRequest request)
    {
        request.Id = id;

        return Ok(await _updateHandler.Handle(request));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await _deleteHandler.Handle(
            new DeleteQuestionCategoryRequest
            {
                Id = id
            }));
    }
}
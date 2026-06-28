using Application.Common.ApiResponse;
using Application.Features.AcademicYears.CreateAcademicYear;
using Application.Features.AcademicYears.DeleteAcademicYear;
using Application.Features.AcademicYears.GetAcademicYearById;
using Application.Features.AcademicYears.GetAcademicYearList;
using Application.Features.AcademicYears.UpdateAcademicYear;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/academic-years")]
public class AcademicYearsController : ControllerBase
{
    private readonly CreateAcademicYearHandler _createHandler;
    private readonly GetAcademicYearByIdHandler _getByIdHandler;
    private readonly GetAcademicYearListHandler _getListHandler;
    private readonly UpdateAcademicYearHandler _updateHandler;
    private readonly DeleteAcademicYearHandler _deleteHandler;

    public AcademicYearsController(
        CreateAcademicYearHandler createHandler,
        GetAcademicYearByIdHandler getByIdHandler,
        GetAcademicYearListHandler getListHandler,
        UpdateAcademicYearHandler updateHandler,
        DeleteAcademicYearHandler deleteHandler)
    {
        _createHandler = createHandler;
        _getByIdHandler = getByIdHandler;
        _getListHandler = getListHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAcademicYearRequest request)
    {
        return Ok(await _createHandler.Handle(request));
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        return Ok(ApiResponse<object>.Ok(await _getListHandler.Handle()));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _getByIdHandler.Handle(
            new GetAcademicYearByIdRequest
            {
                Id = id
            }));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateAcademicYearRequest request)
    {
        request.Id = id;

        await _updateHandler.Handle(request);

        return Ok(ApiResponse<string>.Ok("Updated"));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _deleteHandler.Handle(id);

        return Ok(ApiResponse<string>.Ok("Deleted"));
    }
}
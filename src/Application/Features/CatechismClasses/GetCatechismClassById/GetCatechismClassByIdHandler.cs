using Domain.Interfaces;

namespace Application.Features.CatechismClasses.GetCatechismClassById;

public class GetCatechismClassByIdHandler
{
    private readonly ICatechismClassRepository _repository;

    public GetCatechismClassByIdHandler(
        ICatechismClassRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetCatechismClassByIdResult> Handle(
        GetCatechismClassByIdRequest request)
    {
        var catechismClass = await _repository.GetByIdAsync(request.Id);

        if (catechismClass is null)
        {
            return new GetCatechismClassByIdResult
            {
                Success = false,
                Message = "Không tìm thấy lớp giáo lý."
            };
        }

        return new GetCatechismClassByIdResult
        {
            Success = true,
            Message = "Thành công.",
            Data = new GetCatechismClassByIdResponse
            {
                Id = catechismClass.Id,
                ParishId = catechismClass.ParishId,
                AcademicYearId = catechismClass.AcademicYearId,
                CatechismGradeId = catechismClass.CatechismGradeId,
                Code = catechismClass.Code,
                Name = catechismClass.Name,
                DisplayOrder = catechismClass.DisplayOrder,
                MaxStudents = catechismClass.MaxStudents,
                IsActive = catechismClass.IsActive
            }
        };
    }
}
using Domain.Interfaces;

namespace Application.Features.AcademicYears.GetAcademicYearById;

public class GetAcademicYearByIdHandler
{
    private readonly IAcademicYearRepository _repository;

    public GetAcademicYearByIdHandler(
        IAcademicYearRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetAcademicYearByIdResult> Handle(
        GetAcademicYearByIdRequest request)
    {
        var academicYear = await _repository.GetByIdAsync(request.Id);

        if (academicYear is null)
        {
            return new GetAcademicYearByIdResult
            {
                Success = false,
                Message = "Không tìm thấy năm học."
            };
        }

        return new GetAcademicYearByIdResult
        {
            Success = true,
            Message = "Thành công.",
            Data = new GetAcademicYearByIdResponse
            {
                Id = academicYear.Id,
                ParishId = academicYear.ParishId,
                Code = academicYear.Code,
                Name = academicYear.Name,
                StartDate = academicYear.StartDate,
                EndDate = academicYear.EndDate,
                IsCurrent = academicYear.IsCurrent,
                DisplayOrder = academicYear.DisplayOrder
            }
        };
    }
}
using Domain.Interfaces;

namespace Application.Features.Semesters.GetSemesterById;

public class GetSemesterByIdHandler
{
    private readonly ISemesterRepository _repository;

    public GetSemesterByIdHandler(
        ISemesterRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetSemesterByIdResult> Handle(
        GetSemesterByIdRequest request)
    {
        var semester = await _repository.GetByIdAsync(request.Id);

        if (semester is null)
        {
            return new GetSemesterByIdResult
            {
                Success = false,
                Message = "Không tìm thấy học kỳ."
            };
        }

        return new GetSemesterByIdResult
        {
            Success = true,
            Message = "Thành công.",
            Data = new GetSemesterByIdResponse
            {
                Id = semester.Id,
                AcademicYearId = semester.AcademicYearId,
                Code = semester.Code,
                Name = semester.Name,
                SemesterOrder = semester.SemesterOrder,
                StartDate = semester.StartDate,
                EndDate = semester.EndDate,
                IsCurrent = semester.IsCurrent
            }
        };
    }
}
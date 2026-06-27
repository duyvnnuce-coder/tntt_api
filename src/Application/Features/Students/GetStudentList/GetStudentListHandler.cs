using Domain.Interfaces;

namespace Application.Features.Students.GetStudentList;

public class GetStudentListHandler
{
    private readonly IStudentRepository _repository;

    public GetStudentListHandler(IStudentRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetStudentListResponse>> Handle()
    {
        var students = await _repository.GetListAsync();

        return students.Select(x => new GetStudentListResponse
        {
            Id = x.Id,
            Code = x.Code,
            FullName = x.FullName,
            ChristianName = x.ChristianName,
            Gender = x.Gender
        }).ToList();
    }
}
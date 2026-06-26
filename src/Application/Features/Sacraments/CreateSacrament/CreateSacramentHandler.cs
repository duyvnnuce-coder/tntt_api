using Domain.Entities;
using Domain.Interfaces;

namespace Application.Features.Sacraments.CreateSacrament;

public class CreateSacramentHandler
{
    private readonly ISacramentRepository _repository;
    private readonly IStudentRepository _studentRepository;

    public CreateSacramentHandler(
        ISacramentRepository repository,
        IStudentRepository studentRepository)
    {
        _repository = repository;
        _studentRepository = studentRepository;
    }

    public async Task<CreateSacramentResult> Handle(CreateSacramentRequest request)
    {
        var errors = CreateSacramentValidator.Validate(request);

        if (errors.Any())
        {
            return new CreateSacramentResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        if (!await _studentRepository.ExistsAsync(request.StudentId))
        {
            return new CreateSacramentResult
            {
                Success = false,
                Message = "Học viên không tồn tại."
            };
        }

        if (await _repository.ExistsStudentSacramentAsync(
                request.StudentId,
                request.Type))
        {
            return new CreateSacramentResult
            {
                Success = false,
                Message = "Học viên đã có bí tích này."
            };
        }

        var sacrament = new Sacrament
        {
            StudentId = request.StudentId,
            Type = request.Type,
            ReceivedDate = request.ReceivedDate,
            ChurchName = request.ChurchName,
            Minister = request.Minister,
            CertificateNumber = request.CertificateNumber,
            Note = request.Note
        };

        await _repository.AddAsync(sacrament);

        return new CreateSacramentResult
        {
            Success = true,
            Message = "Thêm bí tích thành công.",
            Data = new CreateSacramentResponse
            {
                Id = sacrament.Id,
                StudentId = sacrament.StudentId,
                Type = sacrament.Type
            }
        };
    }
}
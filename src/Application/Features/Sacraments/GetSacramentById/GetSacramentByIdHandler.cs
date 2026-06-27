using Domain.Interfaces;

namespace Application.Features.Sacraments.GetSacramentById;

public class GetSacramentByIdHandler
{
    private readonly ISacramentRepository _repository;

    public GetSacramentByIdHandler(ISacramentRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetSacramentByIdResult> Handle(GetSacramentByIdRequest request)
    {
        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity == null)
        {
            return new GetSacramentByIdResult
            {
                Success = false,
                Message = "Không tìm thấy bí tích."
            };
        }

        return new GetSacramentByIdResult
        {
            Success = true,
            Message = "Lấy dữ liệu thành công.",
            Data = new GetSacramentByIdResponse
            {
                Id = entity.Id,
                StudentId = entity.StudentId,
                Type = entity.Type,
                ReceivedDate = entity.ReceivedDate,
                ChurchName = entity.ChurchName,
                Minister = entity.Minister,
                CertificateNumber = entity.CertificateNumber,
                Note = entity.Note
            }
        };
    }
}
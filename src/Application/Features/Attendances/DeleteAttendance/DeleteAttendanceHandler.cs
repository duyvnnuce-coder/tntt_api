using Domain.Interfaces;

namespace Application.Features.Attendances.DeleteAttendance;

public class DeleteAttendanceHandler
{
    private readonly IAttendanceRepository _repository;

    public DeleteAttendanceHandler(
        IAttendanceRepository repository)
    {
        _repository = repository;
    }

    public async Task<DeleteAttendanceResult> Handle(
        DeleteAttendanceRequest request)
    {
        var attendance = await _repository.GetByIdAsync(request.Id);

        if (attendance is null)
        {
            return new DeleteAttendanceResult
            {
                Success = false,
                Message = "Không tìm thấy bản ghi điểm danh."
            };
        }

        await _repository.DeleteAsync(attendance);

        return new DeleteAttendanceResult
        {
            Success = true,
            Message = "Xóa điểm danh thành công."
        };
    }
}
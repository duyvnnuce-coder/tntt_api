using Domain.Entities;
using Domain.Interfaces;
using Domain.Enums;

namespace Application.Features.StudentCards.CreateStudentCard;

public class CreateStudentCardHandler
{
    private readonly IStudentCardRepository _repository;
    private readonly IStudentRepository _studentRepository;

    public CreateStudentCardHandler(
        IStudentCardRepository repository,
        IStudentRepository studentRepository)
    {
        _repository = repository;
        _studentRepository = studentRepository;
    }

    public async Task<CreateStudentCardResult> Handle(CreateStudentCardRequest request)
    {
        var errors = CreateStudentCardValidator.Validate(request);

        if (errors.Any())
        {
            return new CreateStudentCardResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        if (!await _studentRepository.ExistsAsync(request.StudentId))
        {
            return new CreateStudentCardResult
            {
                Success = false,
                Message = "Giáo lý sinh không tồn tại."
            };
        }

        if (await _repository.ExistsByStudentIdAsync(request.StudentId))
        {
            return new CreateStudentCardResult
            {
                Success = false,
                Message = "Giáo lý sinh đã có thẻ."
            };
        }

        var entity = new StudentCard
        {
            StudentId = request.StudentId,
            Token = Guid.NewGuid().ToString("N"),
            CardNumber = request.CardNumber,
            IssuedDate = request.IssueDate,
            ExpiredDate = request.ExpiryDate,
            Status = StudentCardStatus.Active,
            PrintCount = 0
        };

        await _repository.AddAsync(entity);

        return new CreateStudentCardResult
        {
            Success = true,
            Message = "Tạo thẻ thành công.",
            Data = new CreateStudentCardResponse
            {
                Id = entity.Id,
                StudentId = entity.StudentId,
                CardNumber = entity.CardNumber
            }
        };
    }
}
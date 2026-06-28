using Application.Common.Enums;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Features.Exams.CreateExam;

public class CreateExamHandler
{
    private readonly IExamRepository _repository;
    private readonly ICodeGenerator _codeGenerator;

    public CreateExamHandler(
        IExamRepository repository,
        ICodeGenerator codeGenerator)
    {
        _repository = repository;
        _codeGenerator = codeGenerator;
    }

    public async Task<CreateExamResult> Handle(
        CreateExamRequest request)
    {
        var validation = CreateExamValidator.Validate(request);

        if (validation != null)
        {
            return new CreateExamResult
            {
                Success = false,
                Message = validation
            };
        }

        var code = await _codeGenerator.GenerateAsync(
            CodeType.Exam,
            Guid.Empty);

        var entity = new Exam
        {
            AssignmentId = request.AssignmentId,
            Code = code,
            Name = request.Name,
            ExamDate = request.ExamDate,
            MaxScore = request.MaxScore,
            IsPublished = request.IsPublished
        };

        await _repository.AddAsync(entity);

        return new CreateExamResult
        {
            Success = true,
            Message = "Tạo kỳ thi thành công.",
            Data = new CreateExamResponse
            {
                Id = entity.Id,
                Code = entity.Code,
                Name = entity.Name
            }
        };
    }
}
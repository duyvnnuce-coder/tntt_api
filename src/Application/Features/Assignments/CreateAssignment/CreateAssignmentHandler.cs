using Domain.Entities;
using Domain.Interfaces;

namespace Application.Features.Assignments.CreateAssignment;

public class CreateAssignmentHandler
{
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly ISemesterRepository _semesterRepository;
    private readonly ICatechismClassRepository _classRepository;
    private readonly ITeacherRepository _teacherRepository;
    private readonly IAssistantRepository _assistantRepository;

    public CreateAssignmentHandler(
        IAssignmentRepository assignmentRepository,
        ISemesterRepository semesterRepository,
        ICatechismClassRepository classRepository,
        ITeacherRepository teacherRepository,
        IAssistantRepository assistantRepository)
    {
        _assignmentRepository = assignmentRepository;
        _semesterRepository = semesterRepository;
        _classRepository = classRepository;
        _teacherRepository = teacherRepository;
        _assistantRepository = assistantRepository;
    }

    public async Task<CreateAssignmentResult> Handle(CreateAssignmentRequest request)
    {
        var errors = CreateAssignmentValidator.Validate(request);

        if (errors.Any())
        {
            return new CreateAssignmentResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        if (!await _semesterRepository.ExistsAsync(request.SemesterId))
            return new CreateAssignmentResult
            {
                Success = false,
                Message = "Học kỳ không tồn tại."
            };

        if (!await _classRepository.ExistsAsync(request.CatechismClassId))
            return new CreateAssignmentResult
            {
                Success = false,
                Message = "Lớp không tồn tại."
            };

        if (!await _teacherRepository.ExistsAsync(request.TeacherId))
            return new CreateAssignmentResult
            {
                Success = false,
                Message = "Giáo lý viên không tồn tại."
            };

        if (request.AssistantId.HasValue &&
            !await _assistantRepository.ExistsAsync(request.AssistantId.Value))
            return new CreateAssignmentResult
            {
                Success = false,
                Message = "Trợ giảng không tồn tại."
            };

        var assignment = new Assignment
        {
            SemesterId = request.SemesterId,
            ClassId = request.CatechismClassId,
            TeacherId = request.TeacherId,
            AssistantId = request.AssistantId,
            IsMainTeacher = request.IsMainTeacher,

            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Note = request.Note
        };

        if (await _assignmentRepository.ExistsDuplicateAsync(
            request.SemesterId,
            request.CatechismClassId,
            request.TeacherId))
        {
            return new CreateAssignmentResult
            {
                Success = false,
                Message = "Giáo lý viên đã được phân công cho lớp này."
            };
        }

        await _assignmentRepository.AddAsync(assignment);

        return new CreateAssignmentResult
        {
            Success = true,
            Message = "Phân công thành công.",
            Data = new CreateAssignmentResponse
            {
                Id = assignment.Id,
                SemesterId = assignment.SemesterId,
                CatechismClassId = assignment.ClassId,
                TeacherId = assignment.TeacherId,
                AssistantId = assignment.AssistantId
            }
        };
    }
}
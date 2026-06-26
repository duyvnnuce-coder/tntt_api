using Application.Common.Enums;
using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CodeGenerator : ICodeGenerator
{
    private readonly IApplicationDbContext _context;

    public CodeGenerator(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> GenerateAsync(
        CodeType codeType,
        Guid parishId,
        CancellationToken cancellationToken = default)
    {
        var prefix = GetPrefix(codeType);

        var year = DateTime.Now.Year.ToString()[2..];

        var start = $"{prefix}{year}";

        int maxNumber = codeType switch
        {
            CodeType.Student =>
                await _context.Students
                    .Where(x => x.ParishId == parishId &&
                                x.Code.StartsWith(start))
                    .Select(x => x.Code)
                    .ToListAsync(cancellationToken)
                    .ContinueWith(ParseMax),

            CodeType.Teacher =>
                await _context.Teachers
                    .Where(x => x.ParishId == parishId &&
                                x.Code.StartsWith(start))
                    .Select(x => x.Code)
                    .ToListAsync(cancellationToken)
                    .ContinueWith(ParseMax),

            CodeType.Assistant =>
                await _context.Assistants
                    .Where(x => x.ParishId == parishId &&
                                x.Code.StartsWith(start))
                    .Select(x => x.Code)
                    .ToListAsync(cancellationToken)
                    .ContinueWith(ParseMax),

            _ => 0
        };

        return $"{start}{(maxNumber + 1):D4}";
    }

    private static int ParseMax(Task<List<string>> task)
    {
        return task.Result
            .Select(x =>
            {
                var number = x[^4..];
                return int.TryParse(number, out var n) ? n : 0;
            })
            .DefaultIfEmpty(0)
            .Max();
    }

    private static string GetPrefix(CodeType type)
    {
        return type switch
        {
            CodeType.Student => "HS",
            CodeType.Teacher => "GV",
            CodeType.Assistant => "TR",
            CodeType.CatechismClass => "LH",
            CodeType.AcademicYear => "NH",
            CodeType.Semester => "HK",
            CodeType.QuestionCategory => "CD",
            CodeType.Question => "CH",
            CodeType.Exam => "KT",
            CodeType.ExamBlueprint => "MD",
            CodeType.GeneratedExam => "DE",
            _ => throw new ArgumentOutOfRangeException(nameof(type))
        };
    }
}
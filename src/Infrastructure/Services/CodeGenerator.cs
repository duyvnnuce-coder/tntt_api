using Application.Common.Enums;
using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CodeGenerator : ICodeGenerator
{
    private readonly AppDbContext _context;

    public CodeGenerator(AppDbContext context)
    {
        _context = context;
    }

    public async Task<string> GenerateAsync(CodeType codeType)
    {
        return codeType switch
        {
            CodeType.Student => await GenerateCodeAsync(
                _context.Students.Select(x => x.Code),
                "HS"),

            CodeType.Teacher => await GenerateCodeAsync(
                _context.Teachers.Select(x => x.Code),
                "GV"),

            CodeType.Assistant => await GenerateCodeAsync(
                _context.Assistants.Select(x => x.Code),
                "PT"),

            CodeType.Exam => await GenerateCodeAsync(
                _context.Exams.Select(x => x.Code),
                "DT"),

            CodeType.Question => await GenerateCodeAsync(
                _context.Questions.Select(x => x.Code),
                "CH"),

            _ => throw new ArgumentOutOfRangeException(nameof(codeType))
        };
    }

    private static async Task<string> GenerateCodeAsync(
        IQueryable<string> query,
        string prefix)
    {
        var lastCode = await query
            .Where(x => x.StartsWith(prefix))
            .OrderByDescending(x => x)
            .FirstOrDefaultAsync();

        var nextNumber = 1;

        if (!string.IsNullOrWhiteSpace(lastCode))
        {
            nextNumber = int.Parse(lastCode[prefix.Length..]) + 1;
        }

        return $"{prefix}{nextNumber:00000000}";
    }
}
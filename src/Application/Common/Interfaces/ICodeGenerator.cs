using Application.Common.Enums;

namespace Application.Common.Interfaces;

public interface ICodeGenerator
{
    Task<string> GenerateAsync(CodeType codeType);
}
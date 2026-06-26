namespace Application.Common.Interfaces;

using Application.Common.Enums;

public interface ICodeGenerator
{
    Task<string> GenerateAsync(
        CodeType codeType,
        Guid parishId,
        CancellationToken cancellationToken = default);
}
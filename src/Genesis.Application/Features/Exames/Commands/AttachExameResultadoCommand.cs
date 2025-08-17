
using MediatR;
namespace Genesis.Application.Features.Exames.Commands;
public record AttachExameResultadoCommand(Guid Id, string? ResultadoResumo, string? ResultadoArquivoUrl) : IRequest<bool>;

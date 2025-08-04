using Genesis.Application.Features.Pacientes.Commands;
using Genesis.Domain.Entities;
using Genesis.Infrastructure.Persistence;
using MediatR;

namespace Genesis.Application.Features.Pacientes.Handlers;

public class CreatePacienteHandler : IRequestHandler<CreatePacienteCommand, Guid>
{
    private readonly GenesisDbContext _context;

    public CreatePacienteHandler(GenesisDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreatePacienteCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var paciente = new Paciente
        {
            Nome = dto.Nome,
            CPF = dto.CPF,
            Email = dto.Email,
            DataNascimento = dto.DataNascimento
        };

        _context.Pacientes.Add(paciente);
        await _context.SaveChangesAsync(cancellationToken);

        return paciente.Id;
    }
}
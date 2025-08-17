using Genesis.Application.Features.Exames.Commands;
using Genesis.Domain.Entities;
using Genesis.Domain.Repositories;
using Genesis.Infrastructure.Persistence;
using MediatR;

namespace Genesis.Application.Features.Exames.Handlers
{
    public class CreateExameHandler : IRequestHandler<CreateExameCommand, Guid>
    {
        private readonly IPacienteRepository _pacienteRepo;
        private readonly IMedicoRepository _medicoRepo;
        private readonly GenesisDbContext _db;

        public CreateExameHandler(
            IPacienteRepository pacienteRepo,
            IMedicoRepository medicoRepo,
            GenesisDbContext db)
        {
            _pacienteRepo = pacienteRepo;
            _medicoRepo = medicoRepo;
            _db = db;
        }

        public async Task<Guid> Handle(CreateExameCommand request, CancellationToken cancellationToken)
        {
            if (!await _pacienteRepo.ExistsAsync(request.PacienteId, cancellationToken))
                throw new KeyNotFoundException("Paciente não encontrado.");

            if (!await _medicoRepo.ExistsAsync(request.MedicoId, cancellationToken))
                throw new KeyNotFoundException("Médico não encontrado.");

            var exame = new Exame
            {
                Id = Guid.NewGuid(),
                Tipo = request.Tipo,
                Status = request.Status,
                PacienteId = request.PacienteId,
                MedicoId = request.MedicoId,
                DataSolicitacao = request.DataSolicitacao,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = request.CreatedBy
            };

            _db.Exames.Add(exame);
            await _db.SaveChangesAsync(cancellationToken);
            return exame.Id;
        }
    }
}
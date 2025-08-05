using Genesis.Shared.DTOs.Paciente;
using MediatR;

namespace Genesis.Application.Features.Pacientes.Queries;

public class GetAllPacientesQuery : IRequest<List<PacienteDto>>
{
}
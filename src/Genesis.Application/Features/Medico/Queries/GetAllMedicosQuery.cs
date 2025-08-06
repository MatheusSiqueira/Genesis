using Genesis.Shared.DTOs.Medico;
using MediatR;

namespace Genesis.Application.Features.Medico.Queries;

public class GetAllMedicosQuery : IRequest<List<MedicoDto>>
{
}

using MediatR;
namespace Genesis.Application.Features.Dashboard.Queries;
public record DashboardSummary(int PacientesTotal, int ExamesTotal, int MedicosTotal, int DeltaPacientes7d, int DeltaExames7d);
public record GetDashboardSummaryQuery() : IRequest<DashboardSummary>;

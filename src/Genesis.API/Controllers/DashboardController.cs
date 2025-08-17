using Genesis.Application.Features.Dashboard.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Genesis.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly IMediator _mediator;
    public DashboardController(IMediator mediator) => _mediator = mediator;
    [Authorize]
    [HttpGet("summary")]
    public Task<DashboardSummary> GetSummary() => _mediator.Send(new GetDashboardSummaryQuery());
}

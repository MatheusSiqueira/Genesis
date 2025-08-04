using Genesis.Application.Features.Pacientes.Commands;
using Genesis.Application.Features.Pacientes.Queries;
using Genesis.Shared.DTOs.Paciente;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Genesis.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PacienteController : ControllerBase
{
    private readonly IMediator _mediator;

    public PacienteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePaciente([FromBody] CreatePacienteDto dto)
    {
        var id = await _mediator.Send(new CreatePacienteCommand(dto));
        return CreatedAtAction(nameof(GetPacienteById), new { id }, null);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPacienteById(Guid id)
    {
        var paciente = await _mediator.Send(new GetPacienteByIdQuery(id));
        return paciente is null ? NotFound() : Ok(paciente);
    }
}
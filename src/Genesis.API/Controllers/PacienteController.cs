using Genesis.Application.Features.Medico.Commands;
using Genesis.Application.Features.Pacientes.Commands;
using Genesis.Application.Features.Pacientes.Queries;
using Genesis.Shared.DTOs.Medico;
using Genesis.Shared.DTOs.Paciente;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

    [Authorize(Roles = "Admin,Medico")]
    [HttpPost]
    public async Task<IActionResult> CreatePaciente([FromBody] CreatePacienteDto dto)
    {
        var id = await _mediator.Send(new CreatePacienteCommand(dto));
        return CreatedAtAction(nameof(GetPacienteById), new { id }, null);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin,Medico")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePacienteDto dto)
    {
        var result = await _mediator.Send(new UpdatePacienteCommand(id, dto));
        return result ? NoContent() : NotFound();
    }

    [Authorize(Roles = "Admin,Medico")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPacienteById(Guid id)
    {
        var paciente = await _mediator.Send(new GetPacienteByIdQuery(id));
        return paciente is null ? NotFound() : Ok(paciente);
    }

    [Authorize(Roles = "Admin,Medico")]
    [HttpGet]
    public async Task<IActionResult> GetAllPacientes()
    {
        var pacientes = await _mediator.Send(new GetAllPacientesQuery());
        return Ok(pacientes);
    }

    [Authorize(Roles = "Admin,Medico")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePaciente(Guid id)
    {
        var result = await _mediator.Send(new DeletePacienteCommand(id));
        return result ? NoContent() : NotFound();
    }

}
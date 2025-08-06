using Genesis.Application.Features.Medico.Commands;
using Genesis.Application.Features.Medico.Queries;
using Genesis.Shared.DTOs.Medico;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Genesis.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MedicoController : ControllerBase
{
    private readonly IMediator _mediator;

    public MedicoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] CreateMedicoDto dto)
    {
        var id = await _mediator.Send(new CreateMedicoCommand(dto));
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Medico")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var medico = await _mediator.Send(new GetMedicoByIdQuery(id));
        return medico is null ? NotFound() : Ok(medico);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var medicos = await _mediator.Send(new GetAllMedicosQuery());
        return Ok(medicos);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateMedicoDto dto)
    {
        var result = await _mediator.Send(new UpdateMedicoCommand(id, dto));
        return result ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteMedicoCommand(id));
        return result ? NoContent() : NotFound();
    }
}
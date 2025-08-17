using Genesis.Application.Features.Exames.Commands;
using Genesis.Application.Features.Exames.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Genesis.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ExamesController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreateExameCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateExameCommand command)
        {
            if (id != command.Id) return BadRequest();
            var success = await _mediator.Send(command);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, [FromQuery] string deletedBy)
        {
            var success = await _mediator.Send(new DeleteExameCommand(id, deletedBy));
            return success ? NoContent() : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var exame = await _mediator.Send(new GetExameByIdQuery(id));
            return exame is not null ? Ok(exame) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var exames = await _mediator.Send(new ListExamesQuery());
            return Ok(exames);
        }
    }
}
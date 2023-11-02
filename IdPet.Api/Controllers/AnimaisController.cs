using IdPet.ApplicationServices.Commands;
using IdPet.ApplicationServices.Dto.Animais;
using IdPet.ApplicationServices.Dto.Medicamentos;
using IdPet.ApplicationServices.Queries;
using IdPet.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace IdPet.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnimaisController : Controller
{
    private readonly IMediator _mediator;

    public AnimaisController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetAnimaisDeUsuario/{UsuarioId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AnimalDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAnimaisDeUsuarioAsync([FromRoute] EncontrarAnimaisDeUsuarioQuery query)
    {
        var result = await _mediator.Send(query);

        if (result.IsNullOrEmpty())
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("GetHistoricoDeMedicamentos/{AnimalId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<HistoricoMedicamentoDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetHistoricoMedicamentoAsync([FromRoute] EncontrarHistoricoVacinacaoQuery query)
    {
        var result = await _mediator.Send(query);

        if (result.IsNullOrEmpty())
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost("PostAdicionarNovoPet")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IEnumerable<HistoricoMedicamentoDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PostAdicionarPet([FromBody] AdicionarPetCommand command)
    {
        try
        {
            var result = await _mediator.Send(command);

            if (result == null)
            {
                return BadRequest();
            }

            return Created("PostAdicionarNovoPet", result);
        }
        catch (BusinessException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
using IdPet.ApplicationServices.Dto.Animais;
using IdPet.ApplicationServices.Queries;
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EncontrarAnimaisDeUsuarioQuery))]
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
}
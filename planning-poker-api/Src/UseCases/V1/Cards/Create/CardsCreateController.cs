using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PlanningPokerApi.Src.Shared.Business;

namespace PlanningPokerApi.Src.UseCases.V1.Cards.Create
{

  [Route("api/v1/cards/create")]
  [ApiController]
  public class CardsCreateController : ControllerBase
  {

    private readonly IBusiness<CardsCreateRequestDto, CardsCreateResponseDto> _business;

    public CardsCreateController(
      IBusiness<CardsCreateRequestDto, CardsCreateResponseDto> business)
    {
      _business = business;
    }

    [HttpPost("")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Authorize]
    public async Task<ActionResult<CardsCreateResponseDto>> Handle(
      [FromBody] CardsCreateRequestDto request)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      return CreatedAtAction(nameof(Handle), await _business.Execute(request));
    }
  }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlanningPokerApi.Src.Shared.Business;

namespace PlanningPokerApi.Src.UseCases.V1.Authentication.Login
{

  [ApiController]
  [Route("api/v1/authentication/login")]
  [Consumes("application/json")]
  [Produces("application/json")]
  public class AuthenticationLoginController : ControllerBase
  {

    private readonly IBusiness<AuthenticationLoginRequestDto, AuthenticationLoginResponseDto> _business;

    public AuthenticationLoginController(
      IBusiness<AuthenticationLoginRequestDto, AuthenticationLoginResponseDto> business)
    {
      _business = business;
    }

    [HttpPost("")]
    public async Task<ActionResult<AuthenticationLoginResponseDto>> Handle(
      [FromBody] AuthenticationLoginRequestDto dto)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      return CreatedAtAction(nameof(Handle), await _business.Execute(dto));
    }
  }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlanningPokerApi.Src.Shared.Business;

namespace PlanningPokerApi.Src.UseCases.V1.Users.Create
{

  [Route("api/v1/users/create")]
  [ApiController]
  public class UsersCreateController : ControllerBase
  {

    private readonly IBusiness<UsersCreateRequestDto, UsersCreateResponseDto> _business;

    public UsersCreateController(IBusiness<UsersCreateRequestDto, UsersCreateResponseDto> business)
    {
      _business = business;
    }

    [HttpPost("")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<ActionResult<UsersCreateResponseDto>> Handle([FromBody] UsersCreateRequestDto request)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      return CreatedAtAction(nameof(Handle), await _business.Execute(request));
    }
  }
}
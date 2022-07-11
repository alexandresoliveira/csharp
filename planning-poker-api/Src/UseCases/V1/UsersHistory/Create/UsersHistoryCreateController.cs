using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PlanningPokerApi.Src.Shared.Business;

namespace PlanningPokerApi.Src.UseCases.V1.UsersHistory.Create
{

  [Route("api/v1/users-histories/create")]
  [ApiController]
  public class UsersHistoryCreateController : ControllerBase
  {

    private readonly IBusiness<UsersHistoryCreateRequestDto, UsersHistoryCreateResponseDto> _business;

    public UsersHistoryCreateController(IBusiness<UsersHistoryCreateRequestDto, UsersHistoryCreateResponseDto> business)
    {
      _business = business;
    }

    [HttpPost("")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Authorize]
    public async Task<ActionResult<UsersHistoryCreateResponseDto>> Handle([FromBody] UsersHistoryCreateRequestDto request)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      return CreatedAtAction(nameof(Handle), await _business.Execute(request));
    }
  }
}
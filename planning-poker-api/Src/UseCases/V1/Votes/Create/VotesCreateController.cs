using System;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PlanningPokerApi.Src.Shared.Business;

namespace PlanningPokerApi.Src.UseCases.V1.Votes.Create
{

  [Route("api/v1/votes/create")]
  [ApiController]
  public class VotesCreateController : ControllerBase
  {

    private readonly IBusiness<VotesCreateRequestDto, VotesCreateResponseDto> _business;

    public VotesCreateController(IBusiness<VotesCreateRequestDto, VotesCreateResponseDto> business)
    {
      _business = business;
    }

    [HttpPost("")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Authorize]
    public async Task<ActionResult<VotesCreateResponseDto>> Handle([FromBody] VotesCreateRequestDto request)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var identity = User.Identity as ClaimsIdentity;
      if (identity == null)
      {
        return BadRequest("You credentials expired");
      }
      
      var uid = identity.FindFirst(ClaimTypes.Sid).Value;
      var userGuidToken = Guid.Parse(uid);

      if (!request.UserId.Equals(userGuidToken))
      {
        return BadRequest("Token id and user id in model is not same");
      }

      return CreatedAtAction(nameof(Handle), await _business.Execute(request));
    }
  }
}
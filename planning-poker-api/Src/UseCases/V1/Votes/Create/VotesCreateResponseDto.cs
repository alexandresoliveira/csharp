using System;

namespace PlanningPokerApi.Src.UseCases.V1.Votes.Create
{
  public class VotesCreateResponseDto
  {

    public Guid Id { get; set; }

    public string UserName { get; set; }

    public string UsersHistoryDescription { get; set; }

    public int CardValue { get; set; }
  }
}
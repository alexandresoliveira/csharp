using System;

namespace PlanningPokerApi.Src.UseCases.V1.Users.Create
{
  public class UsersCreateResponseDto
  {
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }
  }
}
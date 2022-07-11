using System;
using System.ComponentModel.DataAnnotations;

namespace PlanningPokerApi.Src.UseCases.V1.Votes.Create
{
  public class VotesCreateRequestDto
  {

    [Required(ErrorMessage = "{0} collumn is required")]
    public Guid UserId { get; set; }

    [Required(ErrorMessage = "{0} collumn is required")]
    public Guid UsersHistoryId { get; set; }

    [Required(ErrorMessage = "{0} collumn is required")]
    public Guid CardId { get; set; }
  }
}
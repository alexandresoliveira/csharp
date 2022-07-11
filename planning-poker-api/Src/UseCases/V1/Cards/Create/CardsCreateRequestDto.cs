using System.ComponentModel.DataAnnotations;

namespace PlanningPokerApi.Src.UseCases.V1.Cards.Create
{
  public class CardsCreateRequestDto
  {

    [Required(ErrorMessage = "{0} collumn is required")]
    [Range(0, 100, ErrorMessage = "For {0} is permitted values between {1} and {2}")]
    public int Value { get; set; }
  }
}
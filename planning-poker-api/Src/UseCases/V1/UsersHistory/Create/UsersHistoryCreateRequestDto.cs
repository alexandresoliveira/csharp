using System.ComponentModel.DataAnnotations;

namespace PlanningPokerApi.Src.UseCases.V1.UsersHistory.Create
{
  public class UsersHistoryCreateRequestDto
  {

    [Required(ErrorMessage = "{0} collumn is required")]
    [MaxLength(100, ErrorMessage = "Max value of {0} is {1}")]
    [MinLength(3, ErrorMessage = "Min value of {0} is {1}")]
    public string Description { get; set; }
  }
}
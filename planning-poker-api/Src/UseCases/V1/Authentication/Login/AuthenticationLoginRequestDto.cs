using System.ComponentModel.DataAnnotations;

namespace PlanningPokerApi.Src.UseCases.V1.Authentication.Login
{
  public class AuthenticationLoginRequestDto
  {

    [Required(ErrorMessage = "{0} is required")]
    [EmailAddress(ErrorMessage = "{0} is not valid")]
    public string Email { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [MinLength(6, ErrorMessage = "The minimun length of {0} is {1}")]
    public string Password { get; set; }
  }
}
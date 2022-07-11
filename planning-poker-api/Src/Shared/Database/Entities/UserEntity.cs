using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanningPokerApi.Src.Shared.Database.Entities
{

  [Table("users")]
  public class UserEntity : BaseEntity
  {

    [Required(ErrorMessage = "{0} is required")]
    [MaxLength(50, ErrorMessage = "Max value of {0} is {1}")]
    [MinLength(3, ErrorMessage = "Min value of {0} is {1}")]
    [Column("name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [EmailAddress(ErrorMessage = "{0} is not valid")]
    [Column("email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [MinLength(6, ErrorMessage = "Min value of {0} is {1}")]
    [Column("password")]
    public string Password { get; set; }
  }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanningPokerApi.Src.Shared.Database.Entities
{

  [Table("users_history")]
  public class UsersHistoryEntity : BaseEntity
  {

    [Required(ErrorMessage = "{0} is required")]
    [MaxLength(100, ErrorMessage = "Max value of {0} is {1}")]
    [MinLength(3, ErrorMessage = "Min value of {0} is {1}")]
    [Column("description")]
    public string Description { get; set; }
  }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanningPokerApi.Src.Shared.Database.Entities
{

  [Table("cards")]
  public class CardEntity : BaseEntity
  {

    [Required(ErrorMessage = "{0} is required")]
    [Range(0, 100, ErrorMessage = "For {0} is permitted values between {1} and {2}")]
    [Column("value", Order = 1)]
    public int Value { get; set; }
  }
}
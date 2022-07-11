using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanningPokerApi.Src.Shared.Database.Entities
{

  [Table("votes")]
  public class VoteEntity : BaseEntity
  {

    [Required(ErrorMessage = "{0} is required.")]
    [Column("user_id")]
    public UserEntity User { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    [Column("card_id")]
    public CardEntity Card { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    [Column("users_history_id")]
    public UsersHistoryEntity UsersHistory { get; set; }
  }
}
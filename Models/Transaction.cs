using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MStarSupply.Models{
  public enum Type
    {
        income,outcome
    }
public class Transaction
{
  public int Id { get; set; }

  [Range(0, double.PositiveInfinity)]
  public int Quantity { get; set; }

  [StringLength(50, MinimumLength = 3)]
  public required string Location { get; set; }

  [RegularExpression("income|outcome", ErrorMessage = "The Type can be only income or outcome")] 
  public required string Type { get; set; }

  public DateTime CreatedAt { get; set; }

  [Key]
  [ForeignKey("Product")]
  public int ProductId { get; set; }

}
}



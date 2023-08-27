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

  // [Range(0, double.PositiveInfinity)]
  public int Quantity { get; set; }

  // [StringLength(50)]
  public required string Location { get; set; }

  public required string Type { get; set; }

  public required string CreatedAt { get; set; }

  
  [ForeignKey(nameof(Product))]
  public int ProductId { get; set; }
  
  public Product? Product {get;set;}

}
}



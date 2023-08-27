// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;

namespace MStarSupply.Models
{
  public class Product
  {
    public int Id { get; set; }
    // [StringLength(50)]

    public required string Name { get; set; }

    // [StringLength(50)]
    public required string RegNo { get; set; }

    // [StringLength(50)]
    public required string Type { get; set; }

    // [StringLength(100)]
    public required string Description { get; set; }

    // [StringLength(50)]
    public required string Manufacturer { get; set; }


    // [Range(0, double.PositiveInfinity)]
    public int Quantity { get; set; }

    public DateTime CreatedAt { get; set; }

    // public virtual ICollection<Transaction> Transactions { get; set; }
  }
}



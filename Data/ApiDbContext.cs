using Microsoft.EntityFrameworkCore;
using MStarSupply.Models;

namespace MStarSupply.Data;

public class ApiDbContext : DbContext {
  public ApiDbContext(DbContextOptions<ApiDbContext> options): base(options){
    
  }

  public DbSet<Product> Products {get; set;}
  public DbSet<Transaction> Transactions {get; set;}

}
  
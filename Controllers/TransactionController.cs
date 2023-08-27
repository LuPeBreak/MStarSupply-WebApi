using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MStarSupply.Data;
using MStarSupply.Models;

namespace MStarSupply.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
  private readonly ILogger<TransactionController> _logger;
  private readonly ApiDbContext db;

  public TransactionController(ILogger<TransactionController> logger, ApiDbContext context)
  {
    _logger = logger;
    db = context;
  }

  [HttpGet()]
  public async Task<IActionResult> Get()
  {
    var allTransactions = await db.Transactions.Include(transaction => transaction.Product).ToListAsync();

    return Ok(allTransactions);
  }

  [HttpGet]
  [Route("{id}")]
  public async Task<IActionResult> GetById(int id)
  {
    var transaction = await db.Transactions.FindAsync(id);

    if (transaction == null) return NotFound();

    return Ok(transaction);
  }

  [HttpPost]
  public async Task<IActionResult> Post([FromBody] Transaction transaction)
  {
    // ToDo: Update Product quantity when creating a transaction
    // por hora essa responsabilidade esta no front
    // using var databaseTransaction = db.Database.BeginTransaction();

    try
    {
      // var updatedProduct = await db.Products.FindAsync(transaction.ProductId);
      // if("income" == transaction.Type){
      //   updatedProduct.Quantity += transaction.Quantity;
      // }
      // else if(transaction.Type == "outcome"){
      //   updatedProduct.Quantity += transaction.Quantity;
      // } // Deveria usar Patch Delta<product>
      //await db.SaveChangesAsync()
      // databaseTransaction.Commit();

      transaction.Product = await db.Products.FindAsync(transaction.ProductId);
      await db.Transactions.AddAsync(transaction);

      await db.SaveChangesAsync();



      return CreatedAtAction(nameof(GetById),
          new { id = transaction.Id },
          transaction
      );
    }
    catch (System.Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating transaction");
    }

  }

}

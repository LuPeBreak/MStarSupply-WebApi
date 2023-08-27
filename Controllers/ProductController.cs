using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MStarSupply.Data;
using MStarSupply.Models;

namespace MStarSupply.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
  private readonly ILogger<ProductController> _logger;
  private readonly ApiDbContext db;

  public ProductController(ILogger<ProductController> logger, ApiDbContext context)
  {
    _logger = logger;
    db = context;
  }


  [HttpGet()]
  public async Task<IActionResult> Get()
  {
    var allProducts = await db.Products.ToListAsync();

    return Ok(allProducts);
  }

  [HttpGet]
  [Route("{id}")]
  public async Task<IActionResult> GetById(int id)
  {
    var product = await db.Products.FindAsync(id);

    if (product == null) return NotFound();

    return Ok(product);
  }

  [HttpPost]
  public async Task<IActionResult> Post([FromBody] Product product)
  {
    await db.Products.AddAsync(product);
    await db.SaveChangesAsync();

    return CreatedAtAction(nameof(GetById),
        new { id = product.Id },
        product
    );

  }

  [HttpPatch]
  [Route("{id}")]
  public async Task<IActionResult> Put(int id, Product product)
  {
    try
    {
      if (id != product.Id) return BadRequest("Product ID mismatch");

      var productToUpdate = await db.Products.FindAsync(id);

      if (productToUpdate == null) return NotFound($"Product with Id = {id} not found");

      productToUpdate.Quantity= product.Quantity;

      await db.SaveChangesAsync();

      return NoContent();
    }
    catch (System.Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating product");
    }

  }


}

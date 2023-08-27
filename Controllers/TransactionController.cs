using Microsoft.AspNetCore.Mvc;
using MStarSupply.Models;

namespace MStarSupply.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController : ControllerBase
{
    private readonly ILogger<TransactionController> _logger;

    public TransactionController(ILogger<TransactionController> logger)
    {
        _logger = logger;
    }

}

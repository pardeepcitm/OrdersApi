using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdersApi.Data;

namespace OrdersApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    private readonly ILogger<ProfileController> _logger;
    private readonly AppDbContext _context; 
    
    public ProfileController(ILogger<ProfileController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    
    [HttpGet("me")]
    public IActionResult GetMyProfile()
    {
        
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var username = User.Identity?.Name;
        var email = User.FindFirstValue(ClaimTypes.Email);

        return Ok(new 
        { 
            UserId = userId, 
            Username = username, 
            Email = email 
        });
    }
    
    [HttpGet("products")]
    public async Task<OkObjectResult> GetProductInfo()
    {
        _logger.LogInformation("Product info requested by user {User}", User.Identity?.Name);
        var prodcuts = await _context.Products.ToListAsync();
        return Ok( prodcuts);
    }
}
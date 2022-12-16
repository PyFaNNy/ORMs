using EFCore.Interfaces;
using EFCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Controllers;

[ApiController]
public class CustomerCotroller : ControllerBase
{
    private readonly IAppDbContext _dbContext;

    public CustomerCotroller(IAppDbContext dbContext) {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Get all customers
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _dbContext.Customers
            .Include(x => x.Orders)
            .ThenInclude(x => x.OrdersProducts)
            .ThenInclude(x => x.Product)
            .ToListAsync());
    }

    /// <summary>
    /// Add new customer
    /// </summary>
    /// <param name="courier"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Customer customer)
    {
        await _dbContext.Customers.AddAsync(customer);
        await _dbContext.SaveChangesAsync(new CancellationToken());
        return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer);
    }

    /// <summary>
    /// Update customer
    /// </summary>
    /// <param name="id"></param>
    /// <param name="customer"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> AddToPlaylist(Guid id, [FromBody] Customer customer)
    {
        if (_dbContext.Customers.FirstOrDefault(x => x.Id == id) == null)
        {
            return NotFound();
        }
        
        _dbContext.Customers.Update(customer);
        await _dbContext.SaveChangesAsync(new CancellationToken());
        
        return Ok();
    }
}
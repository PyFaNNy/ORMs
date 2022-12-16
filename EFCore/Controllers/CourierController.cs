using EFCore.Interfaces;
using EFCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Controllers;

[ApiController]
public class CourierController : ControllerBase
{
    private readonly IAppDbContext _dbContext;

    public CourierController(IAppDbContext dbContext) {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Get all courier
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _dbContext.Couriers.Include(x => x.Deliveries).ToListAsync());
    }

    /// <summary>
    /// Add new courier
    /// </summary>
    /// <param name="courier"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Courier courier)
    {
        await _dbContext.Couriers.AddAsync(courier);
        await _dbContext.SaveChangesAsync(new CancellationToken());
        return CreatedAtAction(nameof(Get), new { id = courier.Id }, courier);
    }

    /// <summary>
    /// Update courier
    /// </summary>
    /// <param name="id"></param>
    /// <param name="movieId"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCourier(Guid id, [FromBody] Courier courier)
    {
        if (_dbContext.Couriers.FirstOrDefault(x => x.Id == id) == null)
        {
            return BadRequest();
        }
        
        _dbContext.Couriers.Update(courier);
        await _dbContext.SaveChangesAsync(new CancellationToken());
        
        return Ok();
    }
}
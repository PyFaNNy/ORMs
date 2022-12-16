using System.Data.SqlClient;
using Dapper;
using DapperCrud.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperCrud.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public UserController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        var users = await connection.QueryAsync<User>("select * from Users");
        return Ok(users);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpGet("{userId}")]
    public async Task<IActionResult> Get(int userId)
    {
        using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        var users = await connection.QueryAsync<User>("select * from Users where Id = @Id", new {Id = userId});
        return Ok(users);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        await connection.ExecuteAsync("Insert into Users values (@LastName, @FirstName, @Email)",
            new {LastName = user.LastName, FirstName = user.FirstName, Email = user.Email});
        return CreatedAtAction(nameof(Get), new {userId = user.Id}, user);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Update(User user)
    {
        using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        await connection.ExecuteAsync("update Users set LastName = @LastName, FirstName = @FirstName, Email = @Email where Id = @Id)",
            new {LastName = user.LastName, FirstName = user.FirstName, Email = user.Email, Id = user.Id});
        return CreatedAtAction(nameof(Get), new {userId = user.Id}, user);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpDelete("{userId}")]
    public async Task<IActionResult> Delete(int userId)
    {
        using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        await connection.ExecuteAsync("DELETE FROM Users WHERE Id = @Id)", new { Id = userId});
        return NoContent();
    }
}
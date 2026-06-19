using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Orders.Backend2.Data;
using Orders.Shared.Entities;
using System.Threading.Tasks;

namespace Orders.Backend2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContriesController : ControllerBase
{
    private readonly DataContext _context;

    public ContriesController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
        if (country == null)
        {
            return NotFound();
        }

        return Ok(country);
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _context.Countries.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Post(Country country)
    {
        _context.Countries.Add(country);
        await _context.SaveChangesAsync();
        return Ok(country);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
        if (country == null)
        {
            return NotFound();
        }

        _context.Remove(country);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(Country country)
    {
        _context.Update(country);
        await _context.SaveChangesAsync();
        return Ok(country);
    }
}
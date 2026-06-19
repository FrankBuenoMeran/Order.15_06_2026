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
}
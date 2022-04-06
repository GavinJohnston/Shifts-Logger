using Microsoft.AspNetCore.Mvc;

namespace ShiftsLoggerAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ShiftsLoggerController : ControllerBase
{
    private readonly DataContext _context;

    public ShiftsLoggerController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]

    public async Task<ActionResult<List<Shifts>>> Get()
    {
        return Ok(await _context.ShiftsTable.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<Shifts>>> Get(int id)
    {
        var shift = await _context.ShiftsTable.FindAsync(id);
        return Ok(shift);
    }

    [HttpPost]

    public async Task<ActionResult<List<Shifts>>> Post(Shifts newshift)
    {
        _context.ShiftsTable.Add(newshift);
        await _context.SaveChangesAsync();

        return Ok(await _context.ShiftsTable.ToListAsync());
    }

    [HttpPut]

    public async Task<ActionResult<List<Shifts>>> Put(Shifts request)
    {
        var dbShift = await _context.ShiftsTable.FindAsync(request.ShiftId);

        dbShift.Start = request.Start;
        dbShift.End = request.End;
        dbShift.Pay = request.Pay;
        dbShift.Minutes = request.Minutes;
        dbShift.Location = request.Location;

        await _context.SaveChangesAsync();

        return Ok(await _context.ShiftsTable.ToListAsync());
    }

    [HttpDelete]

    public async Task<ActionResult<List<Shifts>>> Delete(int id)
    {
        var shift = await _context.ShiftsTable.FindAsync(id);
        
        _context.ShiftsTable.Remove(shift);
        await _context.SaveChangesAsync();
        return Ok(shift);
    }
}


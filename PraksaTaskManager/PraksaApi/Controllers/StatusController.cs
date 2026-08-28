using Microsoft.AspNetCore.Mvc;
using PraksaApi.Data;
using PraksaApi.Models;
using PraksaApi.Models.DTO;

namespace PraksaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StatusController : ControllerBase
{
    private readonly PraksaContext _context;

    public StatusController(PraksaContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetStatus")]
    public IEnumerable<Status> Get()
    {
        return _context.Statusi;
    }
    [HttpPost(Name = "Kreiranje statusa")]
    public IActionResult CreateStatusi([FromBody] StatusDTO status)
    {
        try
        {
            Status status1 = new Status();
            status1.Naziv = status.Naziv;
            _context.Statusi.Add(status1);
            _context.SaveChanges();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteStatus(int id)
    {
        
        var status = _context.Statusi.Find(id);
        if (status==null)
        return NotFound();
        _context.Statusi.Remove(status);
        _context.SaveChanges();
        return NoContent();
    }
    
    [HttpPut("{id}")]
     public IActionResult UpdateStatusi(int id, StatusDTO status)
    {
        var status1=_context.Statusi.Find(id);
        if(status1==null) 
        return NotFound();
        status1.Naziv = status.Naziv;
        _context.SaveChanges();
        return NoContent();
    }
    [HttpPost("BrojZadatakPoStatusu")]
    public ActionResult<IEnumerable<object>> BrojZadPoStatusu()
    {
        var rezultat = _context.Statusi
        .Select(s => new 
        {
            s.Naziv,
            BrojZadataka=s.Zadacis.Count()
            })
        .OrderByDescending(s=>s.BrojZadataka)
        .ToList();
        return Ok(rezultat);
    }


}

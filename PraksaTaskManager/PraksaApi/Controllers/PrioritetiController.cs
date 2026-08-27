using Microsoft.AspNetCore.Mvc;
using PraksaApi.Data;
using PraksaApi.Models;
using PraksaApi.Models.DTO;

namespace PraksaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PrioritetiController : ControllerBase
{
    private readonly PraksaContext _context;

    public PrioritetiController(PraksaContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetPrioritet")]
    public IEnumerable<Prioriteti> Get()
    {
        return _context.Prioriteti;
    }
    [HttpPost(Name = "Kreiranje prioriteta")]
    public IActionResult CreatePrioriteti([FromBody] PrioritetiDTO prioriteti)
    {
        try
        {
            Prioriteti prioriteti1 = new Prioriteti();
            prioriteti1.Naziv = prioriteti.Naziv;
            _context.Prioriteti.Add(prioriteti1);
            _context.SaveChanges();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
     [HttpDelete("{id}")]
    public IActionResult DeletePrioriteti(int id)
    {
        
        var prioriteti = _context.Prioriteti.Find(id);
        if (prioriteti==null)
        return NotFound();
        _context.Prioriteti.Remove(prioriteti);
        _context.SaveChanges();
        return NoContent();
    }
     [HttpPut("{id}")]
    public IActionResult UpdatePrioriteti(int id, PrioritetiDTO prioriteti)
    {
        var prioriteti1=_context.Prioriteti.Find(id);
        if(prioriteti1==null) 
        return NotFound();
         prioriteti1.Naziv = prioriteti.Naziv;
        _context.SaveChanges();
        return NoContent();
    }



}

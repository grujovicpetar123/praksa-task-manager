using Microsoft.AspNetCore.Mvc;
using PraksaApi.Data;
using PraksaApi.Models;
using PraksaApi.Models.DTO;

namespace PraksaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class KomentariController : ControllerBase
{
    private readonly PraksaContext _context;

    public KomentariController(PraksaContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetKomentari")]
    public IEnumerable<Komentari> Get()
    {
        return _context.Komentari;
    }
    [HttpPost(Name = "Kreiranje komentara")]
    public IActionResult CreateKomentari([FromBody] KomentariDTO komentari)
    {
        try
        {
            Komentari komentari1 = new Komentari();
            komentari1.Tekst = komentari.Tekst;
            komentari1.ZadatakId = komentari.ZadatakId;
            komentari1.KorisnikId = komentari.KorisnikId;
            komentari1.DatumKreiranja = DateTime.Now;
            _context.Komentari.Add(komentari1);
            _context.SaveChanges();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteKomentari(int id)
    {
        
        var komentari = _context.Komentari.Find(id);
        if (komentari==null)
        return NotFound();
        _context.Komentari.Remove(komentari);
        _context.SaveChanges();
        return NoContent();
    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateKomentari(int id, KomentariDTO komentari)
    {
        var komentari1=_context.Komentari.Find(id);
        if(komentari1==null) 
        return NotFound();
        komentari1.Tekst = komentari.Tekst;
        komentari1.ZadatakId = komentari.ZadatakId;
        komentari1.KorisnikId = komentari.KorisnikId;
        komentari1.DatumKreiranja = DateTime.Now;
        _context.SaveChanges();
        return NoContent();
    }



}

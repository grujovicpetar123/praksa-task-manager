using Microsoft.AspNetCore.Mvc;
using PraksaApi.Data;
using PraksaApi.Models;
using PraksaApi.Models.DTO;

namespace PraksaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class KorisniciController : ControllerBase
{
    private readonly PraksaContext _context;

    public KorisniciController(PraksaContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetKorisnici")]
    public IEnumerable<Korisnici> Get()
    {
        return _context.Korisnici;
    }
    [HttpPost(Name = "Kreiranje korisnika")]
    public IActionResult CreateKorisnici([FromBody] KorisniciDTO korisnici)
    {
        try
        {
            Korisnici korisnici1 = new Korisnici();
            korisnici1.Ime = korisnici.Ime;
            korisnici1.Prezime = korisnici.Prezime;
            korisnici1.Email = korisnici.Email;
            korisnici1.DatumKreiranja = DateTime.Now;
            korisnici1.Aktivan = korisnici.Aktivan;
            _context.Korisnici.Add(korisnici1);
            _context.SaveChanges();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteKorisnici(int id)
    {
        
        var korisnici = _context.Korisnici.Find(id);
        if (korisnici==null)
        return NotFound();
        _context.Korisnici.Remove(korisnici);
        _context.SaveChanges();
        return NoContent();
    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateKorisnici(int id, KorisniciDTO korisnici)
    {
        var korisnici1=_context.Korisnici.Find(id);
        if(korisnici1==null) 
        return NotFound();
        korisnici1.Ime = korisnici.Ime;
        korisnici1.Prezime = korisnici.Prezime;
        korisnici1.Email = korisnici.Email;
        korisnici1.DatumKreiranja = DateTime.Now;
        korisnici1.Aktivan = korisnici.Aktivan;
        _context.SaveChanges();
        return NoContent();
    }

}

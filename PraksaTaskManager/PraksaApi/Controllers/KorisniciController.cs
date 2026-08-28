using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        if (korisnici == null)
            return NotFound();
        _context.Korisnici.Remove(korisnici);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateKorisnici(int id, KorisniciDTO korisnici)
    {
        var korisnici1 = _context.Korisnici.Find(id);
        if (korisnici1 == null)
            return NotFound();
        korisnici1.Ime = korisnici.Ime;
        korisnici1.Prezime = korisnici.Prezime;
        korisnici1.Email = korisnici.Email;
        korisnici1.DatumKreiranja = DateTime.Now;
        korisnici1.Aktivan = korisnici.Aktivan;
        _context.SaveChanges();
        return NoContent();
    }

    [HttpGet("Broj zadataka po korisniku")]
    public async Task<ActionResult<IEnumerable<KorisniciDTO>>> ZadaciPoKorisniku()
    {
        var rezultat = _context.Korisnici
        .Select(k => new
        {
            k.Ime,
            k.Prezime,
            BrojZadataka = k.Zadacis.Count()
        })
        .OrderByDescending(k => k.BrojZadataka)
        .ToList();
        return Ok(rezultat);
    }
    [HttpGet("GetAktivniKorisnici")]
    public ActionResult<IEnumerable<KorisniciDTO>> AktivniKorisnici()
    {
        var rezultat = _context.Korisnici
        .Where(k => k.Aktivan == true)
        .Select(k => new KorisniciDTO
        {
            Ime = k.Ime,
            Prezime = k.Prezime,
            Email = k.Email,
            Aktivan=k.Aktivan,
            DatumKreiranja=k.DatumKreiranja
        })
        .ToList();
        return Ok(rezultat);
    }

    [HttpGet("KorisniciPoPrezimenu")]
    public ActionResult<IEnumerable<KorisniciDTO>> KorisniciPoPrezimenu()
    {
        var rezultat = _context.Korisnici
        .OrderBy(k=>k.Prezime)
        .Select(k => new KorisniciDTO
        {
            Ime=k.Ime,
            Prezime=k.Prezime,
            Email=k.Email,
            Aktivan=k.Aktivan 
        })
        .ToList();
        return Ok(rezultat);
    }

    [HttpPost("BrojZadatakPoKorisniku")]
    public ActionResult<IEnumerable<object>> BrojZadPoKor()
    {
        var rezultat = _context.Korisnici
        .Select(k => new 
        {
            k.Ime,
            k.Prezime,
            BrojZadataka=k.Zadacis.Count()
            })
        .OrderByDescending(k=>k.BrojZadataka)
        .ToList();
        return Ok(rezultat);
    }
     [HttpPost("BrojKomentaraPoKorisniku")]
    public ActionResult<IEnumerable<object>> BrojKomPoKor()
    {
        var rezultat = _context.Korisnici
        .Include(k=>k.Komentaris)
        .Select(k => new 
        {
            k.Ime,
            k.Prezime,
            BrojKomentara=k.Komentaris.Count()
            })
        .OrderByDescending(k=>k.BrojKomentara)
        .First();
        return Ok(rezultat);
    }
    [HttpGet("KorisniciViseOd1Nezavrsenog")]
    public ActionResult<IEnumerable<KorinsikFilterDTO>> KorisniciNezavrseniVise()
    {
        var korisnici = _context.Korisnici
        .Include(k=>k.Zadacis)
        .ThenInclude(z=>z.Status)
        .ToList();
        var rezultat= korisnici
        .Select(k =>  
        {
            var dto = new KorinsikFilterDTO();
            dto.Filteri(k);
            return dto;
            })
            .Where(d=>d.BrojNezavrsenihZadataka>1)
            .ToList();    
        return Ok(rezultat);
    }





}

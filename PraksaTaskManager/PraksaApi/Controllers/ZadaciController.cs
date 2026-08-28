using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using PraksaApi.Data;
using PraksaApi.Models;
using PraksaApi.Models.DTO;

namespace PraksaApi.Controllers.DTO;

[ApiController]
[Route("[controller]")]
public class ZadaciController : ControllerBase
{
    private readonly PraksaContext _context;

    public ZadaciController(PraksaContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetZadaci")]
    public IEnumerable<Zadaci> Get()
    {
        return _context.Zadaci;
    }
    [HttpPost(Name = "Kreiranje zadataka")]
    public IActionResult CreateProjekti([FromBody] ZadaciDTO zadaci)
    {
        try
        {
            Zadaci zadaci1 = new Zadaci();
            zadaci1.Naziv = zadaci.Naziv;
            zadaci1.Opis = zadaci.Opis;
            zadaci1.DatumKreiranja = DateTime.Now;
            zadaci1.Rok = zadaci.Rok;
            zadaci1.StatusId = zadaci.StatusId;
            zadaci1.PrioritetId = zadaci.PrioritetId;
            zadaci1.KorisnikId = zadaci.KorisnikId;
            zadaci1.ProjektiId = zadaci.ProjektiId;

            _context.Zadaci.Add(zadaci1);
            _context.SaveChanges();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteZadaci(int id)
    {

        var zadaci = _context.Zadaci.Find(id);
        if (zadaci == null)
            return NotFound();
        _context.Zadaci.Remove(zadaci);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateZadaci(int id, ZadaciDTO zadaci)
    {
        var zadaci1 = _context.Zadaci.Find(id);
        if (zadaci1 == null)
            return NotFound();
        zadaci1.Naziv = zadaci.Naziv;
        zadaci1.Opis = zadaci.Opis;
        zadaci1.DatumKreiranja = DateTime.Now;
        zadaci1.Rok = zadaci.Rok;
        zadaci1.StatusId = zadaci.StatusId;
        zadaci1.PrioritetId = zadaci.PrioritetId;
        zadaci1.KorisnikId = zadaci.KorisnikId;
        zadaci1.ProjektiId = zadaci.ProjektiId;
        _context.SaveChanges();
        return NoContent();
    }
    
    [HttpPost("ZadaciKojimaRokNijeProsao")]
    public ActionResult<IEnumerable<ZadaciDTO>> AktivniZadaci()
    {
        var rezultat = _context.Zadaci
        .Where(z => z.Rok>=DateTime.Today)
        .Select(z => new ZadaciDTO
        {
            Naziv=z.Naziv,
            Opis=z.Opis,
            DatumKreiranja=z.DatumKreiranja,
            Rok=z.Rok,
            PrioritetId=z.PrioritetId,
            ProjektiId=z.ProjektiId,
            KorisnikId=z.KorisnikId,
            StatusId=z.StatusId
            })
        .ToList();
        return Ok(rezultat);
    }
    [HttpPost("SortiraiZadaciPoRokuPaPoPrezimenu")]
    public ActionResult<IEnumerable<object>> SortiraniZadaciPoRN()
    {
        var rezultat = _context.Zadaci
        .Include(z=>z.Status)
        .Include(z=>z.Korisnik)
        .Include(z=>z.Projekti)
        .Include(z=>z.Prioritet)
        .OrderBy(z=>z.Rok)
        .ThenBy(z=>z.Naziv)
        .Select(z => new 
        {
            z.Id,
            NazivZadatka=z.Naziv,
            z.Korisnik.Ime,
            z.Korisnik.Prezime,
            NazivProjekta=z.Projekti.Naziv,
            Status=z.Status.Naziv,
            z.Rok
            })
        .ToList();
        return Ok(rezultat);
    }
    [HttpPost("NezavrseniZadaciKojimaJeRokProsao")]
    public ActionResult<IEnumerable<object>> NezavrseniZadaci()
    {
        var rezultat = _context.Zadaci
        .Include(z=>z.Status)
        .Include(z=>z.Korisnik)
        .Where(z => z.Rok<DateTime.Today && z.Status.Naziv!="ZAVRSEN")
        
        .Select(z => new
        {
            z.Naziv,
            z.Korisnik.Ime,
            z.Korisnik.Prezime,
            NazivProjekta=z.Projekti.Naziv,
            z.Rok,
            KasniDana=DateTime.Today-z.Rok
            })
        .OrderBy(z=>z.KasniDana)
        .ToList();
        return Ok(rezultat);
    }

    [HttpPost("BrojKomentaraPoZadatku")]
    public ActionResult<IEnumerable<object>> BrojKomPoZad()
    {
        var rezultat = _context.Zadaci
        .Include(z=>z.Komentaris)      
        .Select(z => new
        {
            z.Naziv,
            BrojKomentara=z.Komentaris.Count()
            })
        .OrderByDescending(z=>z.BrojKomentara)
        .ToList();
        return Ok(rezultat);
    }

     [HttpPost("ZadaciBezKomentara")]
    public ActionResult<IEnumerable<object>> ZadaciBezKomentara()
    {
        var rezultat = _context.Zadaci
        .Include(z=>z.Komentaris)
        .Where(z=>!z.Komentaris.Any())
        .Select(z => new 
        {
            z.Naziv,
            })
            .ToList();
        return Ok(rezultat);
    }



}

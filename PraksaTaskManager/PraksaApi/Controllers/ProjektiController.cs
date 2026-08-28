using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PraksaApi.Data;
using PraksaApi.Models;
using PraksaApi.Models.DTO;

namespace PraksaApi.Controllers.DTO;

[ApiController]
[Route("[controller]")]
public class ProjektiController : ControllerBase
{
    private readonly PraksaContext _context;

    public ProjektiController(PraksaContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetProjekti")]
    public IEnumerable<Projekti> Get()
    {
        return _context.Projekti;
    }
    [HttpPost(Name = "Kreiranje projekata")]
    public IActionResult CreateProjekti([FromBody] ProjektiDTO projekti)
    {
        try
        {
            Projekti projekti1 = new Projekti();
            projekti1.Naziv = projekti.Naziv;
            projekti1.Opis = projekti.Opis;
            projekti1.DatumKreiranja = DateTime.Now;
            projekti1.Aktivan = projekti.Aktivan;
            _context.Projekti.Add(projekti1);
            _context.SaveChanges();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteProjekti(int id)
    {
        
        var projekti = _context.Projekti.Find(id);
        if (projekti==null)
        return NotFound();
        _context.Projekti.Remove(projekti);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpPut("{id}")]
     public IActionResult UpdateProjekti(int id, ProjektiDTO projekti)
    {
        var projekti1=_context.Projekti.Find(id);
        if(projekti1==null) 
        return NotFound();
        projekti1.Naziv = projekti.Naziv;
        projekti1.Opis = projekti.Opis;
        projekti1.DatumKreiranja = DateTime.Now;
        projekti1.Aktivan = projekti.Aktivan;
        _context.SaveChanges();
        return NoContent();
    }
    [HttpGet("GetAktivniProjekti")]
    public ActionResult<IEnumerable<ProjektiDTO>> AktivniProjekti()
    {
        var rezultat = _context.Projekti
        .Where(p => p.Aktivan == true)
        .Select(p => new ProjektiDTO
        {
            Naziv=p.Naziv,
            Opis=p.Opis,
            DatumKreiranja=p.DatumKreiranja,
            Aktivan=p.Aktivan
            })
        .ToList();
        return Ok(rezultat);
    }
    [HttpPost("BrojZadatakPoProjektu")]
    public ActionResult<IEnumerable<object>> BrojZadPoProj()
    {
        var rezultat = _context.Projekti
        .Select(p => new 
        {
            p.Naziv,
            p.Opis,
            BrojZadataka=p.Zadacis.Count()
            })
        .OrderByDescending(p=>p.BrojZadataka)
        .ToList();
        return Ok(rezultat);
    }
    [HttpPost("ProjektiBezZadataka")]
    public ActionResult<IEnumerable<object>> ProjektiBezZad()
    {
        var rezultat = _context.Projekti
        .Include(p=>p.Zadacis)
        .Where(p=>!p.Zadacis.Any())
        .Select(p => new 
        {
            p.Naziv,
            p.Opis,
            })
        .ToList();
        return Ok(rezultat);
    }
    [HttpPost("ProjektiSaNajviseZad")]
    public ActionResult<IEnumerable<object>> MaxZadPoProj()
    {
        var rezultat = _context.Projekti
        .Include(p=>p.Zadacis)
        .Select(p => new 
        {
            p.Naziv,
            p.Opis,
            BrojZadataka=p.Zadacis.Count()
            })
        .OrderByDescending(p=>p.BrojZadataka)
        .First();
        return Ok(rezultat);
    }
    [HttpPost("ProjektiSaNajviseNezavrsenihZad")]
    public ActionResult<IEnumerable<object>> MaxNezZadPoProj()
    {
        var rezultat = _context.Projekti
        .Select(p => new 
        {
            p.Naziv,
            p.Opis,
            BrojNezavrsenihZadataka=p.Zadacis.Count(z=>z.Status.Naziv!="ZAVRSEN")
            })
        .OrderByDescending(p=>p.BrojNezavrsenihZadataka)
        .ToList();
        return Ok(rezultat);
    }



}

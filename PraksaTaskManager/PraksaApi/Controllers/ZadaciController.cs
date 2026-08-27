using Microsoft.AspNetCore.Mvc;
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




}

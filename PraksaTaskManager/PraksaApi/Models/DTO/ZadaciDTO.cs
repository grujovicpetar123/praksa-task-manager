using System;
using System.Collections.Generic;

namespace PraksaApi.Models.DTO;

public class ZadaciDTO
{


    public string? Naziv { get; set; }

    public string? Opis { get; set; }

    public int? StatusId { get; set; }

    public int? PrioritetId { get; set; }

    public DateTime? Rok { get; set; }

    public DateTime? DatumKreiranja { get; set; }

    public int? KorisnikId { get; set; }

    public int? ProjektiId { get; set; }

    
}

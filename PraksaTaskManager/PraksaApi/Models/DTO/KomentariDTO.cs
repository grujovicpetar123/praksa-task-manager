using System;
using System.Collections.Generic;

namespace PraksaApi.Models.DTO;

public class KomentariDTO
{


    public string? Tekst { get; set; }

    public int? ZadatakId { get; set; }

    public int? KorisnikId { get; set; }

    public DateTime? DatumKreiranja { get; set; }

   
}

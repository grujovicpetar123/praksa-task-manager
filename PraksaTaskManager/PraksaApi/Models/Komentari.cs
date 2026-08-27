using System;
using System.Collections.Generic;

namespace PraksaApi.Models;

public partial class Komentari:Base
{


    public string? Tekst { get; set; }

    public int? ZadatakId { get; set; }

    public int? KorisnikId { get; set; }

    public DateOnly? DatumKreiranja { get; set; }

    public virtual Korisnici? Korisnik { get; set; }

    public virtual Zadaci? Zadatak { get; set; }
}

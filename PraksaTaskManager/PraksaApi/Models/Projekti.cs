using System;
using System.Collections.Generic;

namespace PraksaApi.Models;

public partial class Projekti:Base
{
    

    public string? Naziv { get; set; }

    public string? Opis { get; set; }

    public DateOnly? DatumKreiranja { get; set; }

    public bool? Aktivan { get; set; }

    public virtual ICollection<Zadaci> Zadacis { get; set; } = new List<Zadaci>();
}

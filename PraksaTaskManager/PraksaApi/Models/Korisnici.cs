using System;
using System.Collections.Generic;

namespace PraksaApi.Models;

public partial class Korisnici:Base
{
    

    public DateTime? DatumKreiranja { get; set; }

    public string Ime { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool? Aktivan { get; set; }

    public string Prezime { get; set; } = null!;

    public virtual ICollection<Komentari> Komentaris { get; set; } = new List<Komentari>();

    public virtual ICollection<Zadaci> Zadacis { get; set; } = new List<Zadaci>();
}

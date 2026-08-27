using System;
using System.Collections.Generic;

namespace PraksaApi.Models;

public partial class Zadaci:Base
{


    public string? Naziv { get; set; }

    public string? Opis { get; set; }

    public int? StatusId { get; set; }

    public int? PrioritetId { get; set; }

    public DateTime? Rok { get; set; }

    public DateTime? DatumKreiranja { get; set; }

    public int? KorisnikId { get; set; }

    public int? ProjektiId { get; set; }

    public virtual ICollection<Komentari> Komentaris { get; set; } = new List<Komentari>();

    public virtual Korisnici? Korisnik { get; set; }

    public virtual Prioriteti? Prioritet { get; set; }

    public virtual Projekti? Projekti { get; set; }

    public virtual Status? Status { get; set; }
}

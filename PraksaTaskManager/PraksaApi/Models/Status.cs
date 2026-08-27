using System;
using System.Collections.Generic;

namespace PraksaApi.Models;

public partial class Status
{
    public int StatusId { get; set; }

    public string? Naziv { get; set; }

    public virtual ICollection<Zadaci> Zadacis { get; set; } = new List<Zadaci>();
}

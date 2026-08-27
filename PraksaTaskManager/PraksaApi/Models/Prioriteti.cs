using System;
using System.Collections.Generic;

namespace PraksaApi.Models;

public partial class Prioriteti:Base
{
  

    public string? Naziv { get; set; }

    public virtual ICollection<Zadaci> Zadacis { get; set; } = new List<Zadaci>();
}

using System;
using System.Collections.Generic;

namespace PraksaApi.Models;

public class ProjektiDTO
{
    

    public string? Naziv { get; set; }

    public string? Opis { get; set; }

    public DateTime? DatumKreiranja { get; set; }

    public bool? Aktivan { get; set; }

}

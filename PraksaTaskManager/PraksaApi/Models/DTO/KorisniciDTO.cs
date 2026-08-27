using System;
using System.Collections.Generic;

namespace PraksaApi.Models.DTO;

public class KorisniciDTO
{
    

    public DateOnly? DatumKreiranja { get; set; }

    public string Ime { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool? Aktivan { get; set; }

    public string Prezime { get; set; } = null!;


    
}

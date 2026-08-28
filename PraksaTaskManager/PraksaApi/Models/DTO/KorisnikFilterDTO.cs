using System;
using System.Collections.Generic;
using PraksaApi.Models;

namespace PraksaApi.Models;

public class KorinsikFilterDTO
{
        public string Ime {get;set;} =string.Empty;
        public string Prezime {get;set;} = string.Empty;
        public int BrojNezavrsenihZadataka {get;set;}

        public void Filteri(Korisnici k)
    {
        Ime=k.Ime;
        Prezime=k.Prezime;
        BrojNezavrsenihZadataka=k.Zadacis.Count(z=>z.Status.StatusId!=3);
    }

}

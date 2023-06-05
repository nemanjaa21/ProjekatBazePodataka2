using System;
using System.Collections.Generic;

namespace G3_PR_108_2019_Nemanja_Malinovic.Models;

public partial class PlayListum
{
    public int IdPlay { get; set; }

    public string? NazivPl { get; set; }

    public int? IdKorisnika { get; set; }

    public virtual Korisnik? IdKorisnikaNavigation { get; set; }

    public virtual ICollection<SadrziPlayNum> SadrziPlayNums { get; set; } = new List<SadrziPlayNum>();
}

using System;
using System.Collections.Generic;

namespace G3_PR_108_2019_Nemanja_Malinovic.Models;

public partial class Korisnik
{
    public int IdKorisnika { get; set; }

    public string? Ime { get; set; }

    public string? Prezime { get; set; }

    public string? KorisnickoIme { get; set; }

    public string? Lozinka { get; set; }

    public bool? Pretplacen { get; set; }

    public virtual ICollection<PlayListum> PlayLista { get; set; } = new List<PlayListum>();
}

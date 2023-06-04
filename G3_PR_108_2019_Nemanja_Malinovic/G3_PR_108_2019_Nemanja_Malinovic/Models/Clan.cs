using System;
using System.Collections.Generic;

namespace G3_PR_108_2019_Nemanja_Malinovic.Models;

public partial class Clan
{
    public int IdCl { get; set; }

    public string? Uloga { get; set; }

    public int? IdIzv { get; set; }

    public virtual Grupa? IdIzvNavigation { get; set; }
}

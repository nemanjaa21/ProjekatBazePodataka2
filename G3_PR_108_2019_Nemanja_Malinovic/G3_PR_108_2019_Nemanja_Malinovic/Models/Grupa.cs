using System;
using System.Collections.Generic;

namespace G3_PR_108_2019_Nemanja_Malinovic.Models;

public partial class Grupa
{
    public int IdIzv { get; set; }

    public int? BrNg { get; set; }

    public virtual ICollection<Clan> Clans { get; set; } = new List<Clan>();

    public virtual Izvodjac IdIzvNavigation { get; set; } = null!;
}

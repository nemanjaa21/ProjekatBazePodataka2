using System;
using System.Collections.Generic;

namespace G3_PR_108_2019_Nemanja_Malinovic.Models;

public partial class SoloIzvodjac
{
    public int IdIzv { get; set; }

    public int? BrNs { get; set; }

    public virtual Izvodjac IdIzvNavigation { get; set; } = null!;
}

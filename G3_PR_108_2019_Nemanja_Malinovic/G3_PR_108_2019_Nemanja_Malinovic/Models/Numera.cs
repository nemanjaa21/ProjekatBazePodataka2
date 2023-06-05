using System;
using System.Collections.Generic;

namespace G3_PR_108_2019_Nemanja_Malinovic.Models;

public partial class Numera
{
    public int IdNum { get; set; }

    public int IdIzv { get; set; }

    public string? NazivN { get; set; }

    public DateTime? DatumIz { get; set; }

    public TimeSpan? TrajanjeN { get; set; }

    public double? Ocena { get; set; }

    public virtual Izvodjac IdIzvNavigation { get; set; } = null!;

    public virtual ICollection<ImaZanr> ImaZanrs { get; set; } = new List<ImaZanr>();

    public virtual ICollection<SadrziPlayNum> SadrziPlayNums { get; set; } = new List<SadrziPlayNum>();
}

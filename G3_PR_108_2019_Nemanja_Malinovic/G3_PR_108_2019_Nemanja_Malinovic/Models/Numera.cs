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

    public virtual ICollection<PlayListum> IdPlays { get; set; } = new List<PlayListum>();

    public virtual ICollection<Zanr> IdZs { get; set; } = new List<Zanr>();
}

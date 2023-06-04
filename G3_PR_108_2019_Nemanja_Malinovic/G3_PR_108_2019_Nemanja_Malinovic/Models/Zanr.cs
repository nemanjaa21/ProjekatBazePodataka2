using System;
using System.Collections.Generic;

namespace G3_PR_108_2019_Nemanja_Malinovic.Models;

public partial class Zanr
{
    public int IdZ { get; set; }

    public string? ImeZ { get; set; }

    public string? Vek { get; set; }

    public virtual ICollection<Numera> Ids { get; set; } = new List<Numera>();
}

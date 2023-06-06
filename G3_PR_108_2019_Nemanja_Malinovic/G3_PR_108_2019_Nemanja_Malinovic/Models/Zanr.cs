using System;
using System.Collections.Generic;

namespace G3_PR_108_2019_Nemanja_Malinovic.Models;

public partial class Zanr
{
    public int IdZ { get; set; }

    public string? ImeZ { get; set; }

    public string? Vek { get; set; }

    public virtual ICollection<ImaZanr> ImaZanrs { get; set; } = new List<ImaZanr>();

    public override string ToString()
    {
        return ImeZ;
    }
}

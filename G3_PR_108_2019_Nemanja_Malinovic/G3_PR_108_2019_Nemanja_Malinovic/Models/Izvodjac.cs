using System;
using System.Collections.Generic;

namespace G3_PR_108_2019_Nemanja_Malinovic.Models;

public partial class Izvodjac
{
    public int IdIzv { get; set; }

    public string? ImeIzv { get; set; }

    public DateTime? DatumPocetka { get; set; }

    public virtual Grupa? Grupa { get; set; }

    public virtual ICollection<Numera> Numeras { get; set; } = new List<Numera>();

    public virtual SoloIzvodjac? SoloIzvodjac { get; set; }
}

using System;
using System.Collections.Generic;

namespace G3_PR_108_2019_Nemanja_Malinovic.Models;

public partial class SadrziPlayNum
{
    public int IdPlayNum { get; set; }

    public int? IdPlay { get; set; }

    public int? IdNum { get; set; }

    public int? IdIzv { get; set; }

    public virtual Numera? Id { get; set; }

    public virtual PlayListum? IdPlayNavigation { get; set; }
}

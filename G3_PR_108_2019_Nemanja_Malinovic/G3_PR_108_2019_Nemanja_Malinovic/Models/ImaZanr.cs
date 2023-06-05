using System;
using System.Collections.Generic;

namespace G3_PR_108_2019_Nemanja_Malinovic.Models;

public partial class ImaZanr
{
    public int IdImaZanr { get; set; }

    public int? IdNum { get; set; }

    public int? IdIzv { get; set; }

    public int? IdZ { get; set; }

    public virtual Numera? Id { get; set; }

    public virtual Zanr? IdZNavigation { get; set; }
}

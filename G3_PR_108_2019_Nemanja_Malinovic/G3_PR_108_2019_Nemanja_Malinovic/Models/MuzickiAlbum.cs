using System;
using System.Collections.Generic;

namespace G3_PR_108_2019_Nemanja_Malinovic.Models;

public partial class MuzickiAlbum
{
    public int IdM { get; set; }

    public TimeSpan? TrajanjeM { get; set; }

    public DateTime? DatumIzM { get; set; }

    public int? IdK { get; set; }

    public virtual IzdavackaKuca? IdKNavigation { get; set; }

    public virtual ICollection<Numera> Numeras { get; set; } = new List<Numera>();
}

using System;
using System.Collections.Generic;

namespace G3_PR_108_2019_Nemanja_Malinovic.Models;

public partial class IzdavackaKuca
{
    public int IdK { get; set; }

    public string? NazivK { get; set; }

    public DateTime? DatumOsn { get; set; }

    public virtual ICollection<MuzickiAlbum> MuzickiAlbums { get; set; } = new List<MuzickiAlbum>();
}

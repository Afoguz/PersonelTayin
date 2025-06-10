using System;
using System.Collections.Generic;

namespace PersonelTayin.Models;

public partial class Adliye
{
    public int Id { get; set; }

    public string? AdliyeAdi { get; set; }

    public virtual ICollection<Basvuru> Basvurulars { get; set; } = new List<Basvuru>();

    public static implicit operator Adliye(string v)
    {
        throw new NotImplementedException();
    }
}

using PersonelTayin.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonelTayin.Models;

public class Basvuru
{
    public int Id { get; set; }
    public int UserAccountId { get; set; }
    public UserAccount? UserAccount { get; set; }

    public int AdliyeAdiId { get; set; }
    public Adliye? AdliyeAdi { get; set; }

    public string? BasvuruTuru { get; set; }
    public string? Aciklama { get; set; }
    public DateTime BasvuruTarihi { get; set; }
}


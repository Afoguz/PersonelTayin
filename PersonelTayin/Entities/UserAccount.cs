using Microsoft.EntityFrameworkCore;
using PersonelTayin.Models;
using System.ComponentModel.DataAnnotations;

namespace PersonelTayin.Entities;


[Index(nameof(Email), IsUnique = true)]
[Index(nameof(UserName), IsUnique = true)]

public partial class UserAccount 
{
    [Key] 
    public int Id { get; set; } 

    [Required(ErrorMessage= "İsim Gerekli.")]
    [MaxLength(60, ErrorMessage ="En Fazla 50 Karakter Girilebilir")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Mail Gerekli.")]
    [MaxLength(60, ErrorMessage = "En Fazla 50 Karakter Girilebilir")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Kullanıcı Adı Gerekli.")]
    [MaxLength(60, ErrorMessage = "En Fazla 50 Karakter Girilebilir")]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Şifre Gerekli.")]
    [MaxLength(60, ErrorMessage = "En Fazla 50 Karakter Girilebilir")]
    public string Password { get; set; } = string.Empty;

    public string? Unvan { get; set; }

    public int? Sicil { get; set; }   
    public string? CalistigiAdliye { get; set; }

    public string? CalistigiBirim { get; set; }

    public DateOnly? IseBaslamaTarihi { get; set; }

    public DateOnly? DogumTarihi { get; set; }

    public string? DogumYeri { get; set; }

    public string? Cinsiyet { get; set; }

      public virtual ICollection<Basvuru> Basvurulars { get; set; } = new List<Basvuru>();
}


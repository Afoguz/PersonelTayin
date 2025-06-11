using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PersonelTayin.ViewsModels
{
           public class LoginViewModel
        {
        [Required(ErrorMessage ="Username Gerekli")]
        [MaxLength(60, ErrorMessage = "Max 20 Karakter")]       

        [DisplayName("Usarname")]
        public string? Username { get; set; }

        [Required(ErrorMessage ="Şifre Gerekli.")]
        [StringLength(60, MinimumLength = 6, ErrorMessage ="Max 20 veya Min 5 Karakter Olmalı")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }
    }


    }



using System.ComponentModel.DataAnnotations;

namespace PersonelTayin.ViewsModels
{
    public class AdminViewModel
    {
         
        [Required(ErrorMessage = "Username Gerekli")]        
        public string AdminAdi { get; set; } = "AdaletBakanligi";

        [Required(ErrorMessage = "Şifre Gerekli.")]       
        [DataType(DataType.Password)]
        public string Sifre { get; set; } = "1920";

        public string KullaniciAdi { get; set; } = "admin";

        public bool RememberMe { get; set; }
    }
}




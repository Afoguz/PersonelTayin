using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PersonelTayin.Entities;
using PersonelTayin.Models;

namespace PersonelTayin.ViewsModels
{
    public class IndexViewModel
    {
        public List<UserAccount> Personeller { get; set; }
        public List<Basvuru> Talepler { get; set; }       
        public List<Basvuru> BasvuruYapanlar { get; set; }
    }
}

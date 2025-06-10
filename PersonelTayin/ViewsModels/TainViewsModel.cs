using PersonelTayin.Entities;
using PersonelTayin.Models;

namespace PersonelTayin.ViewsModels
{
    public class TainViewsModel
    {

        public UserAccount Personel { get; set; }
        public List<Basvuru> Talepler { get; set; }
        public List<Adliye> Adliyes { get; set; }


        public int SelectedAdliyeId { get; set; }
        public string TayinTuru { get; set; }
        public string Aciklama { get; set; }
    }
}

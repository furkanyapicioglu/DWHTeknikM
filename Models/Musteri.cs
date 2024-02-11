namespace DWHTeknikM.Models
{
    //musteriBilgileri
    public class Musteri
    {
        public int MusteriNumarasi { get; set; }

        public string? Isim { get; set; }    

        public string? SoyIsim { get; set; }

        public string? DogumYeri { get; set; }

        public int? Yas { get; set; }

        public string? TcKimlikNo { get; set; }  

        public string? Email { get; set; }   

        public string? TelNo { get; set; }   

        public int? AktifMi { get; set; }    

        public string? GuncellemeTarihi { get; set; } 

        public string? EklemeTarihi { get; set; }
    }
}

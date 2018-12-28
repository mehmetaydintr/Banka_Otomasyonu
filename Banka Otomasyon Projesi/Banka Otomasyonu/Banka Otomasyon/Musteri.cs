using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka_Otomasyon
{
    public abstract class Musteri
    {
        public long MusteriNo { get; set; }
        public KimlikBilgisi kimlikBilgisi;
        public List<Hesap> Hesaplar = new List<Hesap>();
        public int k = 0;
        public string MusteriTipi { get; set; }
        public Musteri()
        {
            kimlikBilgisi = new KimlikBilgisi();
        }
        public virtual string MusteriValidasyon()
        {
            string HataMesaji = "";
            if (kimlikBilgisi.TCKimlikNo == 0)
            {
                HataMesaji += "TC Kimlik No Boş Bırakılamaz\n";
                k++;
            }
            if (kimlikBilgisi.Ad == null || kimlikBilgisi.Ad == "")
            {
                HataMesaji += "Ad Boş Bırakılamaz\n";
                k++;
            }
            if (kimlikBilgisi.Soyad == null || kimlikBilgisi.Soyad == "")
            {
                HataMesaji += "Soyad Boş Bırakılamaz\n";
                k++;
            }
            if (kimlikBilgisi.DogumYeri == null || kimlikBilgisi.DogumYeri == "")
            {
                HataMesaji += "Doğum Yeri Boş Bırakılamaz\n";
                k++;
            }
            if (kimlikBilgisi.Cinsiyet != "Erkek" && kimlikBilgisi.Cinsiyet != "Kadın")
            {
                HataMesaji += "Cinsiyet Boş Bırakılamaz\n";
                k++;
            }
            return HataMesaji;
        }
        public virtual void HesapEkle(Hesap h)
        {
            Hesaplar.Add(h);
        }
        public virtual void HesapKapat(Hesap h)
        {
            Hesaplar.Remove(h);
        }
        public virtual decimal HavaleYap(decimal t)
        {
            return t;
        }
    }
}

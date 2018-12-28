using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka_Otomasyon
{
    public class Hesap
    {
        public long HesapNo { get; set; }
        public decimal Bakiye { get; set; }

        public List<IslemBilgisi> IslemBilgileri = new List<IslemBilgisi>();
        public void ParaCek(IslemBilgisi ib)
        {
            ib.Detay = "Para Çekme";
            Bakiye -= ib.Tutar;
            IslemBilgileri.Add(ib);
        }
        public void Iptal(IslemBilgisi ib)
        {
            IslemBilgileri.Remove(ib);
        }
        public void ParaYatir(IslemBilgisi ib)
        {
            ib.Detay = "Para Yatırma";
            Bakiye += ib.Tutar;
            IslemBilgileri.Add(ib);
        }
        public void ParaTranserYap(IslemBilgisi ib)
        {
            IslemBilgileri.Add(ib);
        }
    }
}

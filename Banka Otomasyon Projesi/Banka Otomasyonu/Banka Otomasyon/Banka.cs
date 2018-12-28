using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka_Otomasyon
{
    public class Banka
    {
        public List<Musteri> Musteriler;
        public Banka()
        {
            Musteriler = new List<Musteri>();
        }
        public void MusteriEkle(Musteri m)
        {
            Musteriler.Add(m);
        }
    }
}

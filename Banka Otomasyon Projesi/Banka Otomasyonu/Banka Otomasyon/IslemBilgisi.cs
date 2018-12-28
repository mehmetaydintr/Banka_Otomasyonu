using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka_Otomasyon
{
    public class IslemBilgisi
    {
        public decimal Tutar { get; set; }
        public string Detay { get; set; }
        public DateTime IslemTarihi { get; set; }
        public decimal GunlukParaCekme { get; set; }
        public long HesapNo { get; set; }
        public decimal TransferUcreti { get; set; }
    }
}

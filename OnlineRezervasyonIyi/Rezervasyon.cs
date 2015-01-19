using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRezervasyonIyi
{
    public class Rezervasyon
    {
        public int RezervasyonID { get; set; }
        public Otel OtelAdi { get; set; }
        public DateTime BaslnagicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public int KisiSayisi { get; set; }
    }
}

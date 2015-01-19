using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRezervasyonIyi
{
    public class Tedarikci1:ITedarikci
    {
        public List<Otel> OtelAra(string sehirAdi, DateTime baslangicTarihi, DateTime bitisTarihi, int kisiSayisi)
        {
            //web servisine istek atıldı gibi düşünelim.
            return new List<Otel>();
        }
    }
}

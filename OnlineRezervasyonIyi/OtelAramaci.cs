using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRezervasyonIyi
{
    public class OtelAramaci
    {
        Tedarikci1 tedarikci1 = new Tedarikci1();
        Tedarikci2 tedarikci2 = new Tedarikci2();
        List<Otel> oteller;
        public List<Otel> OtelAra(string sehirAdi, DateTime baslangicTarihi, DateTime bitisTarihi, int kisiSayisi)
        {
            oteller = new List<Otel>();
            oteller.AddRange(tedarikci1.OtelAra(sehirAdi, baslangicTarihi, bitisTarihi, kisiSayisi));
            oteller.AddRange(tedarikci2.OtelAra(sehirAdi, baslangicTarihi, bitisTarihi, kisiSayisi));
            oteller = oteller.GroupBy(i => i.OtelAdi).Select(i => new Otel //en ucuzunu getir.
            {
                OtelAdi = i.Key,
                Ucret = i.Min(j => j.Ucret),
                TedarikciId = i.Min(j => j.TedarikciId)
            }).ToList();
            return oteller;
        }
    }
}

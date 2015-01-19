using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRezervasyonIyi
{
    public class OtelAramaci
    {
        private List<ITedarikci> tedarikciler;

        public OtelAramaci(List<ITedarikci> tedarikciler)
        {
            this.tedarikciler = tedarikciler;
        }

        List<Otel> oteller;
        public List<Otel> OtelAra(string sehirAdi, DateTime baslangicTarihi, DateTime bitisTarihi, int kisiSayisi)
        {
            oteller = new List<Otel>();
            foreach (var tedarikci in tedarikciler)
            {
                oteller.AddRange(tedarikci.OtelAra(sehirAdi, baslangicTarihi, bitisTarihi, kisiSayisi));
            }

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

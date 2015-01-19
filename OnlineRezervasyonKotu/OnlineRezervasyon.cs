using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRezervasyonKotu
{
    public class OnlineRezervasyon
    {
        public List<Otel> OtelAra(string sehirAdi, DateTime baslangicTarihi, DateTime bitisTarihi, int kisiSayisi)
        {
            List<Otel> sonuc = new List<Otel>();
            sonuc.AddRange(Tedarikci1OtelAra(sehirAdi, baslangicTarihi, bitisTarihi, kisiSayisi));
            sonuc.AddRange(Tedarikci2OtelAra(sehirAdi, baslangicTarihi, bitisTarihi, kisiSayisi));
            sonuc = sonuc.GroupBy(i => i.OtelAdi).Select(i => new Otel //en ucuzunu getir.
            {
                OtelAdi = i.Key,
                Ucret = i.Min(j => j.Ucret),
                TedarikciID = i.Min(j => j.TedarikciID)
            }).ToList();
            return sonuc;
        }

        private List<Otel> Tedarikci1OtelAra(string sehirAdi, DateTime baslangicTarihi, DateTime bitisTarihi, int kisiSayisi)
        {
            //web servisine istek atıldı gibi düşünelim.
            return new List<Otel>();
        }

        private List<Otel> Tedarikci2OtelAra(string sehirAdi, DateTime baslangicTarihi, DateTime bitisTarihi, int kisiSayisi)
        {
            //web servisine istek atıldı gibi düşünelim.
            return new List<Otel>();
        }

        public bool RezervasyonYap(Otel otel, DateTime baslangicTarihi, DateTime bitisTarihi, int kisiSayisi)
        {
            return true;
        }

        public void RezervasyonYapilanOtelListesiCiktisiAl()
        {
            //burada veritabanına bağlanıp rezervasyon yapılan otellerin listesini çektiğimizi düşünüyorz.
            //sonra excel e cikti alınıyor.
        }
    }
}

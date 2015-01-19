using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRezervasyonIyi
{
    public class RezervasyonCiktiAlici
    {
        private List<Rezervasyon> rezervasyonlar;
        public void RezervasyonCiktiAl()
        { 
            //burada veritabanına bağlanıp rezervasyonlar çekildiği düşünülür.
            rezervasyonlar = new List<Rezervasyon>();
            //daha sonra çıktı alınır.

        }
    }
}

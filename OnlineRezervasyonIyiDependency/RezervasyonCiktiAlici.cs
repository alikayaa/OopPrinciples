using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRezervasyonIyi
{
    public class RezervasyonCiktiAlici
    {
        ICiktiAl ciktiAlici;
        public RezervasyonCiktiAlici(ICiktiAl ciktiAlici)
        {
            this.ciktiAlici = ciktiAlici;
        }

        public void RezervasyonCiktiAl(List<Rezervasyon> rezervasyonlar)
        { 
            //daha sonra çıktı alınır.
            ciktiAlici.CiktiAl(rezervasyonlar);
        }
    }
}

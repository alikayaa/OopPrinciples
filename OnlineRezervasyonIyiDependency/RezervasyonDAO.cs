using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRezervasyonIyi
{
    public class RezervasyonDAO
    {
        private Rezervasyon rezervasyon;
        public Rezervasyon RezervasyonYap()
        {
            //burada rezervasyon bilgilerinin alınıp veritabanına kaydedildiği düşünülür.
            rezervasyon = new Rezervasyon();
            return rezervasyon;
        }

        public List<Rezervasyon> GetRezervasyonlar()
        { 
            //burada veritabanından rezervasyonların çekildiği düşünülür.
            return new List<Rezervasyon>();
        }


    }
}

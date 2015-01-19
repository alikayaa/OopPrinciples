using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnaylamaSistemiKotu
{
    public interface IReservation
    {
        string GetKullaniciAdi();
        string GetOtelBilgileri();

        string KrediKartiNumarasi { get; set; }
        bool KrediKartiylaOde();

        int KasaNumarasi { get; set; }
        bool KasadakiParaylaOde();

        void RezervasyonuOnayla();
    }
}

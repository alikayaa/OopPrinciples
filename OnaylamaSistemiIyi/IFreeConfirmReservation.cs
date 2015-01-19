using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnaylamaSistemiIyi
{
    public interface IFreeConfirmReservation
    {
        string GetKullaniciAdi();
        string GetOtelBilgileri();

        void RezervasyonuOnayla();
    }
}

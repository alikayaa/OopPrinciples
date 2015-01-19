using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnaylamaSistemiIyi
{
    public class CreditCardConfirm:ICreditCardConfirmReservation
    {
        public string KrediKartiNumarasi { get; set; }

        public bool KrediKartiylaOde()
        {
            throw new NotImplementedException();
        }

        public string GetKullaniciAdi()
        {
            throw new NotImplementedException();
        }

        public string GetOtelBilgileri()
        {
            throw new NotImplementedException();
        }

        public void RezervasyonuOnayla()
        {
            throw new NotImplementedException();
        }
    }
}

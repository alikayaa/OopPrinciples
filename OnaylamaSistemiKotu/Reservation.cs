using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnaylamaSistemiKotu
{
    public class Reservation:IReservation
    {
        public string GetKullaniciAdi()
        {
            return "Kullanıcı Adı";
        }
        
        public string GetOtelBilgileri()
        {
            return "Otel Bilgileri";
        }

        public string KrediKartiNumarasi { get; set; }

        public bool KrediKartiylaOde()
        {
            //Kredi kartıyla ödeme işlemi
            return true;//bankadan gelen cevaba göre dönüyoruz.
        }

        public int KasaNumarasi { get; set; }

        public bool KasadakiParaylaOde()
        {
            //Kasadaki parayla öde
            return true;
        }

        private int onaylamaSecenegi;//yapıcı metodtan aldığımızı düşünelim
        public void RezervasyonuOnayla()
        {
            //burada if-else blokları kullanarak kullanıcının kasadan mı ödeyeceği
            //kredi kartıyla mı ödeyeceği yoksa ücretsiz mi alabileceği anlaşılır.
            if (onaylamaSecenegi == 1)//ücretsiz onaylama mı
            { 
                //TODO: Onaylama işlemleri
            }
            else if (onaylamaSecenegi == 2)//Kredi kartıyla ödeyip onaylama
            {
                bool sonuc=KrediKartiylaOde();
                if (sonuc)
                { 
                    //TODO: Onaylama işlemleri
                }
            }
            else if (onaylamaSecenegi == 3)//Kasadaki parayla ödeyip onaylama
            {
                bool sonuc = KasadakiParaylaOde();
                if(sonuc)
                {
                    //TODO: Onaylama işlemleri
                }
            }

        }
    }
}

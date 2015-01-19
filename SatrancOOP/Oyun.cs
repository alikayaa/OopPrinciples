using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SatrancOOP
{
    public class Oyun
    {
        #region Fields

        private Tahta oyunTahtasi;
        private Oyuncu beyazOyuncu;
        private Oyuncu siyahOyuncu;
        private static Oyun oyun;
        private List<Tas> elenenTaslar;
        #endregion

        #region Properties

        public Tahta OyunTahtasi {get{ return oyunTahtasi;} }
        public Oyuncu BeyazOyuncu { get { return beyazOyuncu; } }
        public Oyuncu SiyahOyuncu { get { return siyahOyuncu; } }
        public List<Tas> ElenenTaslar { get { return elenenTaslar; } set { elenenTaslar = value; } }

        #endregion

        #region Constructer

        private Oyun()
        {
            elenenTaslar = new List<Tas>(); 
            this.OyunuBaslat();
        }

        #endregion

        #region Methods

        public static Oyun GetInstance()
        {
            if (oyun == null)
                oyun = new Oyun();
            return oyun;
        }

        private void OyunuBaslat()
        {
            List<Kare> kareler = KareleriOlustur();//64 kare oluşturuldu.
            BeyazTaslariYerlestir(kareler);//karelerin üstüne beyaz taşları yerleştir.
            SiyahTaslariYerlestir(kareler);//karelerin üstüne siyah taşları yerleştir.

            Oyuncu oyuncu1 = new Oyuncu(TakimRengi.Beyaz, "Oyuncu1");//1. oyuncu oluşturulur.
            Oyuncu oyuncu2 = new Oyuncu(TakimRengi.Siyah, "Oyuncu2");//2. oyuncu oluşturulur.

            Tahta oyunTahtasi = new Tahta(kareler);//taşlarla ilişkilendirilen kareler tahtanın üstüne yerleştirilir.
            this.oyunTahtasi = oyunTahtasi;
        }

        private void BeyazTaslariYerlestir(List<Kare> kareler)
        {
            #region Beyaz Piyonlar

            for (int x = 0; x < 8; x++)
            {
                //y ekseni hep 1
                Kare k = kareler.Where(i => i.KonumY == 1 && i.KonumX == x).First();
                Piyon piyon = new Piyon(TakimRengi.Beyaz,k);
                k.UzerindeBulunanTas = piyon;
            }
            #endregion

            #region Beyaz Kareler

            Kare solkalekare = kareler.Where(i => i.KonumY == 0 && i.KonumX == 0).First();
            Kale solkale = new Kale(TakimRengi.Beyaz, solkalekare);
            solkalekare.UzerindeBulunanTas = solkale;

            Kare sagkalekare = kareler.Where(i => i.KonumY == 0 && i.KonumX == 7).First();
            Kale sagkale = new Kale(TakimRengi.Beyaz, sagkalekare);
            sagkalekare.UzerindeBulunanTas = sagkale;
            
            #endregion

            #region Beyaz Atlar

            Kare solatkare = kareler.Where(i => i.KonumY == 0 && i.KonumX == 1).First();
            At solAt = new At(TakimRengi.Beyaz, solatkare);
            solatkare.UzerindeBulunanTas = solAt;

            Kare sagatkare = kareler.Where(i => i.KonumY == 0 && i.KonumX == 6).First();
            At sagAt = new At(TakimRengi.Beyaz, sagatkare);
            sagatkare.UzerindeBulunanTas = sagAt;

            #endregion

            #region Beyaz Filler

            Kare solfilkare = kareler.Where(i => i.KonumY == 0 && i.KonumX == 2).First();
            Fil solFil = new Fil(TakimRengi.Beyaz, solfilkare);
            solfilkare.UzerindeBulunanTas = solFil;

            Kare sagfilkare = kareler.Where(i => i.KonumY == 0 && i.KonumX == 5).First();
            Fil sagFil = new Fil(TakimRengi.Beyaz, sagfilkare);
            sagfilkare.UzerindeBulunanTas = sagFil;

            #endregion

            #region Beyaz Vezir

            Kare vezirkare = kareler.Where(i => i.KonumY == 0 && i.KonumX == 3).First();
            Vezir vezir = new Vezir(TakimRengi.Beyaz, vezirkare);
            vezirkare.UzerindeBulunanTas = vezir;

            #endregion

            #region Beyaz Şah

            Kare sahkare = kareler.Where(i => i.KonumY == 0 && i.KonumX == 4).First();
            Sah sah = new Sah(TakimRengi.Beyaz, sahkare);
            sahkare.UzerindeBulunanTas = sah;

            #endregion

        }

        private void SiyahTaslariYerlestir(List<Kare> kareler)
        {
            #region Siyah Piyonlar

            for (int x = 0; x < 8; x++)
            {
                //y ekseni hep 6
                Kare k = kareler.Where(i => i.KonumY == 6 && i.KonumX == x).First();
                Piyon piyon = new Piyon(TakimRengi.Siyah, k);
                k.UzerindeBulunanTas = piyon;
            }
            #endregion

            #region Siyah Kareler

            Kare solkalekare = kareler.Where(i => i.KonumY == 7 && i.KonumX == 0).First();
            Kale solkale = new Kale(TakimRengi.Siyah, solkalekare);
            solkalekare.UzerindeBulunanTas = solkale;

            Kare sagkalekare = kareler.Where(i => i.KonumY == 7 && i.KonumX == 7).First();
            Kale sagkale = new Kale(TakimRengi.Siyah, sagkalekare);
            sagkalekare.UzerindeBulunanTas = sagkale;

            #endregion

            #region Siyah Atlar

            Kare solatkare = kareler.Where(i => i.KonumY == 7 && i.KonumX == 1).First();
            At solAt = new At(TakimRengi.Siyah, solatkare);
            solatkare.UzerindeBulunanTas = solAt;

            Kare sagatkare = kareler.Where(i => i.KonumY == 7 && i.KonumX == 7).First();
            At sagAt = new At(TakimRengi.Siyah, sagatkare);
            sagatkare.UzerindeBulunanTas = sagAt;

            #endregion

            #region Siyah Filler

            Kare solfilkare = kareler.Where(i => i.KonumY == 7 && i.KonumX == 2).First();
            Fil solFil = new Fil(TakimRengi.Siyah, solfilkare);
            solfilkare.UzerindeBulunanTas = solFil;

            Kare sagfilkare = kareler.Where(i => i.KonumY == 7 && i.KonumX == 5).First();
            Fil sagFil = new Fil(TakimRengi.Siyah, sagfilkare);
            sagfilkare.UzerindeBulunanTas = sagFil;

            #endregion

            #region Siyah Vezir

            Kare vezirkare = kareler.Where(i => i.KonumY == 7 && i.KonumX == 3).First();
            Vezir vezir = new Vezir(TakimRengi.Siyah, vezirkare);
            vezirkare.UzerindeBulunanTas = vezir;

            #endregion

            #region Beyaz Şah

            Kare sahkare = kareler.Where(i => i.KonumY == 7 && i.KonumX == 4).First();
            Sah sah = new Sah(TakimRengi.Siyah, sahkare);
            sahkare.UzerindeBulunanTas = sah;

            #endregion

        }

        private List<Kare> KareleriOlustur()
        {
            List<Kare> kareler = new List<Kare>();
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Kare kare = new Kare(x, y);
                    kareler.Add(kare);
                }
            }
            return kareler;
        }

        #endregion

    }
}

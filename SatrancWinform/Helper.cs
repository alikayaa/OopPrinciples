using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SatrancOOP;

namespace SatrancWinform
{
    public class Helper
    {
        public static bool SahMi(FrmMain form, Label lblSira)
        {
            bool sahmi = false;
            if (string.Equals(lblSira.Tag.ToString(), "Beyaz"))//sıra beyazdaysa siyahın şah çekme olasılığı var
            {
                foreach (var item in form.Controls)
                {
                    PictureBox pb = item as PictureBox;
                    if (pb != null && pb.Name != "pbTahta")
                    {
                        Kare kare = (Kare)pb.Tag;
                        if (kare.UzerindeBulunanTas != null && kare.UzerindeBulunanTas.TasRengi == TakimRengi.Siyah)
                        {//tüm siyah taşlar karşı tarafın şahını yiyebilir mi diye kontrol et
                            //beyaz şah siyahlar tarafından bir sonraki el yenebilir mi
                            sahmi = kare.UzerindeBulunanTas.IlerleyebilirMi(GetSah(TakimRengi.Beyaz));
                            if (sahmi) break;
                        }
                    }
                }
            }
            else//sıra siyahdaysa beyazın şah çekme olasılığı var
            {
                foreach (var item in form.Controls)
                {
                    PictureBox pb = item as PictureBox;
                    if (pb != null && pb.Name != "pbTahta")
                    {
                        Kare kare = (Kare)pb.Tag;
                        if (kare.UzerindeBulunanTas != null && kare.UzerindeBulunanTas.TasRengi == TakimRengi.Beyaz)
                        {//tüm siyah taşlar karşı tarafın şahını yiyebilir mi diye kontrol et
                            //siyah şah beyazlar tarafından bir sonraki el yenebilir mi
                            sahmi = kare.UzerindeBulunanTas.IlerleyebilirMi(GetSah(TakimRengi.Siyah));
                            if (sahmi) break;
                        }
                    }
                }
            }
            return sahmi;
        }

        public static Kare GetSah(TakimRengi takimrengi)
        { 
            return Oyun.GetInstance().OyunTahtasi.Kareler.Where(i => i.UzerindeBulunanTas is Sah && i.UzerindeBulunanTas.TasRengi == takimrengi).First();
        }

        public static void GidebilecegiYerleriBoya(FrmMain form)
        {
            foreach (var item in form.Controls)
            {
                PictureBox pb = item as PictureBox;
                if (pb != null && pb.Name != "pbTahta")
                {
                    Kare kare = (Kare)pb.Tag;
                    bool gidebilirmi = form.seciliKare.UzerindeBulunanTas.IlerleyebilirMi(kare);
                    if (gidebilirmi)
                        pb.BorderStyle = BorderStyle.Fixed3D;
                }
            }
        }

        public static void BoyalariKaldir(FrmMain form)
        {
            foreach (var item in form.Controls)
            {
                PictureBox pb = item as PictureBox;
                if (pb != null && pb.Name != "pbTahta")
                {
                    pb.BorderStyle = BorderStyle.None;
                }
            }
        }

        public static PictureBox GetPictureBox(FrmMain form,Kare kare)
        {
            foreach (var item in form.Controls)
            {
                PictureBox pb = item as PictureBox;
                if (pb != null && pb.Name != "pbTahta")
                {
                    int x = int.Parse(pb.Name.Substring(2, 1));
                    int y = int.Parse(pb.Name.Substring(3, 1));
                    if (kare.KonumX == x && kare.KonumY == y)
                        return pb;
                }
            }
            return null;
        }

        public static int GetXCoord(string x)
        {
            switch (x)
            {
                case "a": return 0;
                case "b": return 1;
                case "c": return 2;
                case "d": return 3;
                case "e": return 4;
                case "f": return 5;
                case "g": return 6;
                case "h": return 7;
                default:
                    return -1;
            }
        }

        public static string GetXCoordinatByKare(FrmMain form)
        {
            if (form.seciliKare != null)
            {
                switch (form.seciliKare.KonumX)
                {
                    case 0: return "a";
                    case 1: return "b";
                    case 2: return "c";
                    case 3: return "d";
                    case 4: return "e";
                    case 5: return "f";
                    case 6: return "g";
                    case 7: return "h";
                    default:
                        return "";
                }
            }
            else
                return "";
        }

        public static Kare GetIstenenKare(int x, int y)
        {
            return Oyun.GetInstance().OyunTahtasi.Kareler.Where(i => i.KonumX == x && i.KonumY == y).First();
        }
    }
}

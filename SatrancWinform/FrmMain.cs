using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SatrancOOP;

namespace SatrancWinform
{
    public partial class FrmMain : Form
    {
        public Oyun oyun;
        public Kare seciliKare;
        public FrmMain()
        {
            InitializeComponent();
            OyunuYukle();
        }

        private void OyunuYukle()
        {
            lblSira.Tag = "Beyaz";
            oyun = Oyun.GetInstance();
            pbTahta.Tag = oyun.OyunTahtasi;
            foreach (var item in this.Controls)
            {
                PictureBox pb = item as PictureBox;
                if (pb != null && pb.Name != "pbTahta")
                {
                    pb.Cursor = Cursors.Hand;
                    int x = int.Parse(pb.Name.Substring(2, 1));
                    int y = int.Parse(pb.Name.Substring(3, 1));
                    pb.Tag = oyun.OyunTahtasi.Kareler.Where(i => i.KonumX == x && i.KonumY == y).First();
                }
            }
        }

        private void btnIlerleYe_Click(object sender, EventArgs e)
        {
            if (lbX.SelectedItem == null || lbY.SelectedItem == null)
            {
                lblNot.Text = "Gitmek isteğiniz koordinatı seçin"; return;
            }

            int istenenX = Helper.GetXCoord(lbX.SelectedItem.ToString());
            int istenenY = int.Parse(lbY.SelectedItem.ToString())-1;
            Kare gidilmekIstenenKare = Helper.GetIstenenKare(istenenX, istenenY);
            if (seciliKare != null && seciliKare.UzerindeBulunanTas!=null)
            {
                bool gidebilirmi = seciliKare.UzerindeBulunanTas.IlerleyebilirMi(gidilmekIstenenKare);
                if (gidebilirmi)
                {
                    if (Helper.SahMi(this,lblSira))
                    {
                        MessageBox.Show("Karşı takım size şah çekmiş bu durumdan kurtulmaya çalışın");
                        lblNot.Text = "Şahı koruyunn";
                        return;
                    }
                }
                if (gidebilirmi)
                {
                    PictureBox seciliPb = Helper.GetPictureBox(this, seciliKare);
                    PictureBox istenenKare = Helper.GetPictureBox(this, gidilmekIstenenKare);

                    Image img = seciliPb.Image;
                    istenenKare.Image = img;
                    seciliPb.Image = null;

                    seciliKare.UzerindeBulunanTas.Ilerle(gidilmekIstenenKare);
                    string sira = lblSira.Tag.ToString();
                    lblSira.Tag =sira=="Beyaz"?"Siyah":"Beyaz";
                    lblSira.Text = sira=="Beyaz"?"Sıra Siyahlı Oyuncuda":"Sıra Beyazlı Oyuncuda";
                }
                seciliKare = null;
                if (Helper.SahMi(this,lblSira))
                {
                    MessageBox.Show("ŞAH!!!!!!");
                    lblNot.Text = "ŞAH!!!!";
                }
            }
            else
            {
                lblNot.Text = "Önce hamle yapmak istediğiniz taşı seçin";
            }
        }

        private void pb_Click(object sender, EventArgs e)
        {
            Helper.BoyalariKaldir(this);
            PictureBox pb = sender as PictureBox;
            if (pb != null)
            {
                seciliKare = (Kare)pb.Tag;
                if (seciliKare.UzerindeBulunanTas != null)
                {
                    string text = Helper.GetXCoordinatByKare(this) + " - "+(seciliKare.KonumY + 1).ToString();
                    if ((string.Equals(lblSira.Tag, "Beyaz") && seciliKare.UzerindeBulunanTas.TasRengi == TakimRengi.Beyaz)
                        ||
                        (string.Equals(lblSira.Tag, "Siyah") && seciliKare.UzerindeBulunanTas.TasRengi == TakimRengi.Siyah)
                        )
                    {
                        lblSeciliKare.Text = text;
                        Helper.GidebilecegiYerleriBoya(this);
                    }
                    else
                    {
                       lblSeciliKare.Text = "Karşı takımın taşını seçemezsiniz!!";
                    }
                }
                else
                {
                    lblSeciliKare.Text = "Seçtiğiniz karede taş yok";
                }
            }
        }

    }
}

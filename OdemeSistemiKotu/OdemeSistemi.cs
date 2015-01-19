using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdemeSistemiKotu
{
    public class OdemeSistemi
    {
        private KrediKartiIleOdeme krediKartiOdeme;
        private HaveleIleOdeme havaleOdeme;
        private KapidaOdeme kapidaOdeme;

        public OdemeSistemi()
        {
            krediKartiOdeme = new KrediKartiIleOdeme();
            havaleOdeme = new HaveleIleOdeme();
            kapidaOdeme = new KapidaOdeme();
        }

        public void OdemeYap(int odemeTipi)
        {
            if (odemeTipi == 1)
                KrediKartiIleOde();
            else if (odemeTipi == 2)
                HavaleIleOde();
            else if (odemeTipi == 3)
                KapidaOde();
            else
                throw new ApplicationException("Sistem seçili ödeme tipini desteklemiyor.");
        }

        private string KrediKartiIleOde()
        {
            return krediKartiOdeme.OdemeYap();
        }

        private string HavaleIleOde()
        {
            return havaleOdeme.OdemeYap();
        }

        private string KapidaOde()
        {
            return kapidaOdeme.OdemeYap();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdemeSistemiIyi
{
    public class OdemeSistemi
    {
        private IOdemeTipi odemeTipi;

        public OdemeSistemi(IOdemeTipi odemeTipi)
        {
            this.odemeTipi = odemeTipi;
        }

        public void OdemeYap()
        {
            this.odemeTipi.OdemeYap();
        }
    }
}

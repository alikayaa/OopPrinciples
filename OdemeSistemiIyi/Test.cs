using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdemeSistemiIyi
{
    public class Test
    {
        public OdemeSistemi odemeSistemi;

        public Test(IOdemeTipi odemeTipi)
        {
            odemeSistemi = new OdemeSistemi(odemeTipi);
        }
    }
}

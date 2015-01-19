using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdemeSistemiKotu
{
    public class Test
    {
        OdemeSistemi os = null;
        public Test()
        {
            os=new OdemeSistemi();
        }

        public void main()
        {
            os.OdemeYap(1);
        }

    }
}

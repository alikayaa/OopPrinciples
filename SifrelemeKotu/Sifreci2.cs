using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SifrelemeKotu
{
    public class Sifreci2:ISifreci
    {
        public string Sifrele(string sifrelenecekMetin)
        {
            return sifrelenecekMetin + "%";
        }

        public string Coz(string cozulecekMetin)
        {
            return cozulecekMetin.Split('%')[0];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SifrelemeKotu
{
    //tamamen kaba koddur
    public class Sifreci1:ISifreci
    {
        public string Sifrele(string sifrelenecekMetin)
        {
            return sifrelenecekMetin + "sifre";
        }

        public string Coz(string cozulecekMetin)
        {
            return cozulecekMetin.Substring(0, cozulecekMetin.Length - 5);
        }
    }
}

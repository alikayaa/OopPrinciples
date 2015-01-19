using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SifrelemeKotu
{
    public class Sifreci3:ISifreci
    {
        public string Sifrele(string sifrelenecekMetin)
        {
            return sifrelenecekMetin.Substring(0, sifrelenecekMetin.Length - 3);
        }

        public string Coz(string cozulecekMetin)
        {
            throw new NotImplementedException();
        }
    }
}

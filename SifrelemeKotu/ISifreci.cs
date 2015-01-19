using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SifrelemeKotu
{
    public interface ISifreci
    {
        string Sifrele(string sifrelenecekMetin);
        string Coz(string cozulecekMetin);
    }
}

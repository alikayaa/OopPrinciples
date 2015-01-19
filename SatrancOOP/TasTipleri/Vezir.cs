using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatrancOOP
{
    public class Vezir : Tas
    {
        public Vezir(TakimRengi tasRengi, Kare bulunduguKare)
            : base(tasRengi, bulunduguKare)
        {

        }

        public override bool IlerleyebilirMi(Kare gidecegiKare)
        {
            return base.ruleManager.CaprazIlerleyebilirMi(this.BulunduguKare, gidecegiKare) ||
                   base.ruleManager.YatayDikeyGidebilirMi(this.BulunduguKare, gidecegiKare);
        }
    }
}

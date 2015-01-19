using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SatrancOOP
{
    public class Fil : Tas
    {
        public Fil(TakimRengi tasRengi, Kare bulunduguKare)
            :base(tasRengi,bulunduguKare)
        {

        }

        public override bool IlerleyebilirMi(Kare gidecegiKare)
        {
            return base.ruleManager.CaprazIlerleyebilirMi(this.BulunduguKare, gidecegiKare);
        }
    }
}

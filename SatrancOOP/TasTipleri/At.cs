using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatrancOOP
{
    public class At : Tas
    {
        public At(TakimRengi tasRengi, Kare bulunduguKare)
            : base(tasRengi, bulunduguKare)
        {

        }

        public override bool IlerleyebilirMi(Kare gidecegiKare)
        {
            return base.ruleManager.LSeklindeGidebilirMi(this.BulunduguKare, gidecegiKare);
        }
    }
}

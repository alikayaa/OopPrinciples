using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SatrancOOP
{
    public class Piyon : Tas
    {
        #region Constructers

        public Piyon(TakimRengi tasRengi,Kare bulunduguKare)
            :base(tasRengi,bulunduguKare)
        {

        }

        #endregion

        public override bool Ye(Kare kare)
        {
            if (base.ruleManager.PiyonlaYiyebilirMi(this.BulunduguKare, kare))
            {
                Oyun.GetInstance().ElenenTaslar.Add(kare.UzerindeBulunanTas);
                this.BulunduguKare.UzerindeBulunanTas = null;
                this.BulunduguKare = kare;
                kare.UzerindeBulunanTas = this;

                return true;

            }
            else
                return false;
        }

        public override bool IlerleyebilirMi(Kare gidecegiKare)
        {
            return base.ruleManager.TekBirimDikeyGidebilirMi(this.BulunduguKare, gidecegiKare) ||
                   base.ruleManager.PiyonlaYiyebilirMi(this.BulunduguKare,gidecegiKare);
        }
    }
}

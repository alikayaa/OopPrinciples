using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SatrancOOP
{
    public abstract class Tas
    {
        #region Fields

        private TakimRengi tasRengi;
        private Kare bulunduguKare;
        protected BusinessRule ruleManager;

        #endregion

        #region Properties

        public TakimRengi TasRengi{get{return tasRengi; }}

        public Kare BulunduguKare{get { return bulunduguKare;} set{ bulunduguKare = value;}}

        #endregion

        #region Constructers

        public Tas(TakimRengi tasRengi,Kare bulunduguKare)
        {
            this.tasRengi = tasRengi;
            this.bulunduguKare = bulunduguKare;
            this.ruleManager = new BusinessRule();
        }

        #endregion

        #region Methods

        public abstract bool IlerleyebilirMi(Kare gidecegiKare);

        public bool Ilerle(Kare gidecegiKare)//Ilerleme kuralı değişiyor sadece ilerlenince yapılacaklar aynı
        {
            if (IlerleyebilirMi(gidecegiKare))//ilerleyebileceği bir yere gitmek istiyorsa
            {
                if(gidecegiKare.UzerindeBulunanTas!=null)
                    Oyun.GetInstance().ElenenTaslar.Add(gidecegiKare.UzerindeBulunanTas);
                this.BulunduguKare.UzerindeBulunanTas = null;
                this.BulunduguKare = gidecegiKare;
                gidecegiKare.UzerindeBulunanTas = this;
                
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual bool Ye(Kare kare)
        {
            if (this.IlerleyebilirMi(kare))//ilerleyemezse yiyemez. Ancak piyonda farklı dolayısıyla virtual
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

        #endregion
    }
}

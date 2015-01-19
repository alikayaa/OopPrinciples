using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SatrancOOP
{
    public class Oyuncu
    {
        #region Fields 

        private TakimRengi takimRengi;
        private string oyuncuAdi;

        #endregion

        #region Properties

        public TakimRengi Renk
        {
            get
            {
                return takimRengi;
            }
        }

        public string OyuncuAdi
        {
            get
            {
                return oyuncuAdi;
            }
        }

        #endregion

        #region Constructers

        public Oyuncu(TakimRengi takimRengi,string oyuncuAdi)
        {
            this.takimRengi = takimRengi;
            this.oyuncuAdi = oyuncuAdi;
        }

        #endregion
    }
}

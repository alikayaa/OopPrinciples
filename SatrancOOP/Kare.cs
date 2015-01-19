using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SatrancOOP
{
    public class Kare
    {
        #region Fields

        private int konumX;
        private int konumY;
        private Tas uzerindeBulunanTas;

        #endregion

        #region Properties

        public int KonumX{get{return konumX;}}

        public int KonumY{get{return konumY;}}

        public Tas UzerindeBulunanTas{ get{ return uzerindeBulunanTas; }set {uzerindeBulunanTas = value;}}

        #endregion

        #region Constructer

        public Kare(int konumX,int konumY)
        {
            this.konumX = konumX;
            this.konumY = konumY;
        }

        #endregion
    }
}

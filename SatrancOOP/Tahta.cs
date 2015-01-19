using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SatrancOOP
{
    public class Tahta
    {
        #region Fields

        private List<Kare> kareler;

        #endregion

        #region Properties

        public List<Kare> Kareler
        {
            get
            {
                return kareler;
            }
        }

        #endregion

        #region Constructer

        public Tahta(List<Kare> kareler)
        {
            this.kareler = kareler;
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnaylamaSistemiIyi
{
    public interface ICreditCardConfirmReservation : IFreeConfirmReservation
    {
        string KrediKartiNumarasi { get; set; }
        bool KrediKartiylaOde();
    }
}

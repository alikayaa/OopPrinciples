using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnaylamaSistemiIyi
{
    public interface ICashConfirmReservation:IFreeConfirmReservation
    {
        int KasaNumarasi { get; set; }
        bool KasadakiParaylaOde();
    }
}

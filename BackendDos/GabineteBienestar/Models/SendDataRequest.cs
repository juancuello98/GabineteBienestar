using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GabineteBienestar.Models
{
    public class SendDataRequest
    {
        /*public string Nombre { set; get; } --- Aca no haria falta pasar el nombre ya que en el proceso de 
         bizuit se obtiene como resultado de la consulta que se hace con el DNI.*/

        public int Documento { set; get; }
        public int ReasonId { set; get; }
        public string TimePreferencesId { set; get; }
        public string Observaciones { set; get; }
    }
}

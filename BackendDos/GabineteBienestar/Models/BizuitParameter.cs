using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GabineteBienestar.Models
{
    public class BizuitParameter
    {
        public int Documento { set; get; }
        public string Motivo { set; get; }
        public string preferenciaHoraria { set; get; }
        public string Observaciones { set; get; }
    }
}

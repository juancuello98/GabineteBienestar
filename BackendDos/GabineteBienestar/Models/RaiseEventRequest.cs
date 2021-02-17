using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GabineteBienestar.Models
{
    public class RaiseEventRequest
    {
        public string eventName { get; set; } // GabineteBienestar, nombre del proceso que voy a ejecutar, lo sacamos del archivo de configuracion
        public BizuitParameter[] parameters { get; set; }

    }
}

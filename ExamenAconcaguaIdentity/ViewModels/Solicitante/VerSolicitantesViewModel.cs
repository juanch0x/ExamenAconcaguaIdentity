using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenAconcagua.ViewModels.Solicitante
{
    public class VerSolicitantesViewModel
    {

    }

    public class SolicitanteViewModel
    {
        public long Id { get; set; }
        public string NombreCompleto { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public bool PrestamoVigente { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenAconcaguaIdentity.ViewModels.Prestamos
{
    public class DetallePrestamoViewModel
    {
        public long Id { get; set; }
        public string DniSolicitante { get; set; }
        public string NombreCompletoSolicitante { get; set; }
        public decimal MontoPrestamo { get; set; }
        public int Cuotas { get; set; }
        public DateTimeOffset? FechaAutorizacion { get; set; }
        public DateTimeOffset? FechaTentativa { get; set; }
        public bool PrestamoAutorizado => FechaAutorizacion.HasValue && FechaTentativa.HasValue;
        public IList<CuotaViewModel> Pagos { get; set; }
    }

    public class CuotaViewModel
    {
        public long Id { get; set; }
        public decimal Monto { get; set; }
        public int NumeroDeCuota { get; set; }
        public bool Pagado { get; set; }
        public DateTimeOffset FechaCuota { get; set; }
    }
}

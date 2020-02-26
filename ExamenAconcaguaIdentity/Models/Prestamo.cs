using ExamenAconcagua.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenAconcagua.Models
{
    public class Prestamo : EntityBase, IPrestamo
    {
        public long IdSolicitante { get; set; }        
        [ForeignKey(nameof(IdSolicitante))]
        public Solicitante Solicitante { get; set; }
        public decimal MontoSolicitado { get; set; }
        public DateTimeOffset? AutorizacionDelPrestamo { get; set; }
        public DateTimeOffset? FechaTentativaDeEntrega { get; set; }

        public int Cuotas { get; set; }
        public ICollection<Cuota> Pagos { get; set; } = new HashSet<Cuota>();
    }
}

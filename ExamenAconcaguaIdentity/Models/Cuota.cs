using ExamenAconcagua.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenAconcagua.Models
{
    public class Cuota : EntityBase, ICuota
    {
        public DateTimeOffset FechaPago { get; set; }
        public bool Pagado { get; set; }
        public decimal TotalCuota { get; set; }

        public long PrestamoId { get; set; }
        [ForeignKey(nameof(PrestamoId))]
        public Prestamo Prestamo { get; set; }

    }
}

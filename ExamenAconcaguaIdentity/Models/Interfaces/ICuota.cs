using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamenAconcagua.Models.Interfaces
{
    public interface ICuota : IEntity
    {
        DateTimeOffset FechaPago { get; set; }
        bool Pagado { get; set; }
        decimal TotalCuota { get; set; }
        long PrestamoId { get; set; }
    }

}

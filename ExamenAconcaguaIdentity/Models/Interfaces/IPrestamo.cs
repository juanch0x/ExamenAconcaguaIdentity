using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenAconcagua.Models.Interfaces
{
    public interface IPrestamo : IEntity
    {
        long IdSolicitante { get; set; }        
        Solicitante Solicitante { get; set; }
        decimal MontoSolicitado { get; set; }
        DateTimeOffset? AutorizacionDelPrestamo { get; set; }
        DateTimeOffset? FechaTentativaDeEntrega { get; set; }
        ICollection<Cuota> Pagos { get; set; }
        int Cuotas { get; set; }
    }
}

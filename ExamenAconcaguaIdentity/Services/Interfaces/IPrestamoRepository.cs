using ExamenAconcagua.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenAconcagua.Services.Interfaces
{
    public interface IPrestamoRepository : IRepository<Prestamo>
    {
        Prestamo GetBySolicitante(string dni);
    }
}

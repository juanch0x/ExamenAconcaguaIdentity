using ExamenAconcagua.Models;
using ExamenAconcagua.Services.Interfaces;
using ExamenAconcaguaIdentity.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenAconcagua.Services
{
    public class PrestamoRepository : EntityRepository<Prestamo>, IPrestamoRepository
    {
        public PrestamoRepository(DbContext context) : base(context)
        {}

        public Prestamo GetBySolicitante(string dni)
        {
            throw new NotImplementedException();
            //var localDbContext = (ApplicationDbContext)Context;
            //var solicitante = localDbContext.Solicitantes.FirstOrDefault(x => x.Dni == dni) ?? throw new ArgumentOutOfRangeException();            
        }

        public override Prestamo Get(long Id)
        {
            var context = (ApplicationDbContext)Context;

            return context.Prestamos
                            .Include(x => x.Solicitante)
                            .Include(x => x.Pagos)
                            .Where(x => x.Id == Id).SingleOrDefault();
        }


    }
}

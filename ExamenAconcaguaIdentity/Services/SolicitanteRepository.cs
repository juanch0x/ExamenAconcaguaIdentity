using ExamenAconcagua.Models;
using ExamenAconcagua.Services.Interfaces;
using ExamenAconcaguaIdentity.Data;
using System.Linq;

namespace ExamenAconcagua.Services
{
    public class SolicitanteRepository : EntityRepository<Models.Solicitante> ,ISolicitanteRepository
    {
        public SolicitanteRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            
        }

        public Solicitante GetByDni(string dni)
        {
            return DbSet.SingleOrDefault(x => x.Dni == dni);
        }
    }
}

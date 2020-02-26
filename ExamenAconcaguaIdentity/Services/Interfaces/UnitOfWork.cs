using ExamenAconcaguaIdentity.Data;
using System.Threading.Tasks;

namespace ExamenAconcagua.Services.Interfaces
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context; 
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this._context = dbContext;
            SolicitanteRepository = new SolicitanteRepository(dbContext);
            PrestamoRepository = new PrestamoRepository(dbContext);
        }

        public ISolicitanteRepository SolicitanteRepository { get; }
        public IPrestamoRepository PrestamoRepository { get; }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        public IDatabaseTransaction BeingTransaction()
        {
            return new EntityDatabaseTransaction(_context);
        }

    }
}

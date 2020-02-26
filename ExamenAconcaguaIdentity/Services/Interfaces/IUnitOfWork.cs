using System;
using System.Threading.Tasks;

namespace ExamenAconcagua.Services.Interfaces
{
    public interface IUnitOfWork 
    {
        IDatabaseTransaction BeingTransaction();
        ISolicitanteRepository SolicitanteRepository { get; }
        IPrestamoRepository PrestamoRepository { get; }
        void Save();
        Task SaveAsync();
    }
}

using ExamenAconcagua.Models;

namespace ExamenAconcagua.Services.Interfaces
{
    public interface ISolicitanteRepository : IRepository<Models.Solicitante>
    {
        Solicitante GetByDni(string dni);
    }
}

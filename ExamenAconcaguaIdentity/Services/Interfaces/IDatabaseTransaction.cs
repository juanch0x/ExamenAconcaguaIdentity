using System;

namespace ExamenAconcagua.Services.Interfaces
{
    public interface IDatabaseTransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}

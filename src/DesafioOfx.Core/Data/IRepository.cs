using DesafioOfx.Core.DomainObjects;
using System;

namespace DesafioOfx.Core.Data
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }
    }
}

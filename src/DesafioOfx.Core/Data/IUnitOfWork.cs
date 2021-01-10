using System.Threading.Tasks;

namespace DesafioOfx.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}

using System.Threading.Tasks;

namespace Shift.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
using Shift.Core.Data;
using Shift.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Domain.Interfaces
{
    public interface IEstadoRepository : IRepository<Estado>
    {
        Task<Estado> GetById(Guid id);
        Task<IEnumerable<Estado>> GetAll();
        Task<Estado> GetByIBGE(string ibge);
        void Add(Estado estado);
        void Update(Estado estado);
        void Remove(Estado estado);
    }
}

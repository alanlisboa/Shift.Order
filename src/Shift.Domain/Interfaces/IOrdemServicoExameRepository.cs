using Shift.Core.Data;
using Shift.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Domain.Interfaces
{
    public interface IOrdemServicoExameRepository : IRepository<OrdemServicoExame>
    {
        Task<OrdemServicoExame> GetById(Guid id);
        Task<IEnumerable<OrdemServicoExame>> GetAll(Guid ordemServicoId);
        void Add(OrdemServicoExame item);
        void Update(OrdemServicoExame item);
        void Remove(OrdemServicoExame item);
    }
}

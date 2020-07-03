using Shift.Core.Data;
using Shift.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Domain.Interfaces
{
    public interface IOrdemServicoRepository : IRepository<OrdemServico>
    {
        Task<OrdemServico> GetById(Guid id);
        Task<IEnumerable<OrdemServico>> GetAll();
        Task<OrdemServico> GetByNumber(int number);
        Task<int> GetLastNumber();
        void Add(OrdemServico ordemServico);
        void Update(OrdemServico ordemServico);
        void Remove(OrdemServico ordemServico);
    }
}

using Shift.Core.Data;
using Shift.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Domain.Interfaces
{
    public interface IMedicoRepository : IRepository<Medico>
    {
        Task<Medico> GetById(Guid id);
        Task<IEnumerable<Medico>> GetAll();
        //Task<Medico> GetByCRM(string crm);
        //void Add(Medico medico);
        //void Update(Medico medico);
        //void Remove(Medico medico);
    }
}

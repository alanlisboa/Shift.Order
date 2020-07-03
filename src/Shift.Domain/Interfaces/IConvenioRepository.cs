using Shift.Core.Data;
using Shift.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Domain.Interfaces
{
    public interface IConvenioRepository : IRepository<Convenio>
    {
        Task<Convenio> GetById(Guid id);
        Task<IEnumerable<Convenio>> GetAll();
        Task<Convenio> GetByName(string name);
        void Add(Convenio convenio);
        void Update(Convenio convenio);
        void Remove(Convenio convenio);
    }
}

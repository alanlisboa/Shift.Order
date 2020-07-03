using Shift.Core.Data;
using Shift.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Domain.Interfaces
{
    public interface IEspecialidadeRepository : IRepository<Especialidade>
    {
        Task<Especialidade> GetById(Guid id);
        Task<IEnumerable<Especialidade>> GetAll();
        Task<Especialidade> GetByName(string name);
        void Add(Especialidade especialidade);
        void Update(Especialidade especialidade);
        void Remove(Especialidade especialidade);
    }
}

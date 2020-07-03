using Shift.Core.Data;
using Shift.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Domain.Interfaces
{
    public interface ICidadeRepository : IRepository<Cidade>
    {
        Task<Cidade> GetById(Guid id);
        Task<IEnumerable<Cidade>> GetAll();
        Task<Cidade> GetByIBGE(string ibge);
        void Add(Cidade convenio);
        void Update(Cidade convenio);
        void Remove(Cidade convenio);
    }
}

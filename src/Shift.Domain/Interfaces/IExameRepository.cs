using Shift.Core.Data;
using Shift.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Domain.Interfaces
{
    public interface IExameRepository : IRepository<Exame>
    {
        Task<Exame> GetById(Guid id);
        Task<IEnumerable<Exame>> GetAll();
        //Task<Exame> GetByANS(string ans);
        //void Add(Exame exame);
        //void Update(Exame exame);
        //void Remove(Exame exame);
    }
}

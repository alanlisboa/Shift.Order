using Shift.Core.Data;
using Shift.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Domain.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> GetById(Guid id);
         void Add(Endereco endereco);
        void Update(Endereco endereco);
        void Remove(Endereco endereco);
    }
}

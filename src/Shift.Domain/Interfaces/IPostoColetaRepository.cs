using Shift.Core.Data;
using Shift.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Domain.Interfaces
{
    public interface IPostoColetaRepository : IRepository<PostoColeta>
    {
        Task<PostoColeta> GetById(Guid id);
        Task<IEnumerable<PostoColeta>> GetAll();
        //void Add(PostoColeta postoColeta);
        //void Update(PostoColeta postoColeta);
        //void Remove(PostoColeta postoColeta);
    }
}

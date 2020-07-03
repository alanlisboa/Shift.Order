using Microsoft.EntityFrameworkCore;
using Shift.Core.Data;
using Shift.Data.Contexts;
using Shift.Domain.Interfaces;
using Shift.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Data.Repositories
{
    public class PostoColetaRepository : IPostoColetaRepository
    {
        protected readonly ShiftContext Context;
        protected readonly DbSet<PostoColeta> DbSet;

        public PostoColetaRepository(ShiftContext context)
        {
            Context = context;
            DbSet = Context.Set<PostoColeta>();
        }

        public IUnitOfWork UnitOfWork => Context;

        public void Dispose() => Context.Dispose();

        public async Task<IEnumerable<PostoColeta>> GetAll() => await DbSet.ToListAsync();

        public async Task<PostoColeta> GetById(Guid id) => await DbSet.FindAsync(id);
    }
}

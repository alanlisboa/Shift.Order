using Microsoft.EntityFrameworkCore;
using Shift.Core.Data;
using Shift.Data.Contexts;
using Shift.Domain.Interfaces;
using Shift.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Data.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        protected readonly ShiftContext Context;
        protected readonly DbSet<Medico> DbSet;

        public MedicoRepository(ShiftContext context)
        {
            Context = context;
            DbSet = Context.Set<Medico>();
        }

        public IUnitOfWork UnitOfWork => Context;

        public void Dispose() => Context.Dispose();

        public async Task<IEnumerable<Medico>> GetAll() => await DbSet
            .Include(m => m.Especialidade)
            .ToListAsync();

        public async Task<Medico> GetById(Guid id) => await DbSet
            .Include(m => m.Especialidade)
            .Where(m => m.Id == id)
            .FirstOrDefaultAsync();
    }
}

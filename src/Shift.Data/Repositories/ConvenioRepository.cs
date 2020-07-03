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
    public class ConvenioRepository : IConvenioRepository
    {
        protected readonly ShiftContext Context;
        protected readonly DbSet<Convenio> DbSet;

        public ConvenioRepository(ShiftContext context)
        {
            Context = context;
            DbSet = Context.Set<Convenio>();
        }

        public IUnitOfWork UnitOfWork => Context;

        public void Add(Convenio convenio) => DbSet.Add(convenio);

        public void Dispose() => Context.Dispose();

        public async Task<IEnumerable<Convenio>> GetAll() =>
            await DbSet.ToListAsync();

        public async Task<Convenio> GetById(Guid id) =>
            await DbSet.FindAsync(id);

        public async Task<Convenio> GetByName(string name) =>
            await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Nome == name);

        public void Remove(Convenio convenio) => DbSet.Remove(convenio);

        public void Update(Convenio convenio) => DbSet.Update(convenio);
    }
}

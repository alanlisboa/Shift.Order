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
    public class ExameRepository : IExameRepository
    {
        protected readonly ShiftContext Context;
        protected readonly DbSet<Exame> DbSet;

        public ExameRepository(ShiftContext context)
        {
            Context = context;
            DbSet = Context.Set<Exame>();
        }

        public IUnitOfWork UnitOfWork => Context;

        public void Dispose() => Context.Dispose();

        public async Task<IEnumerable<Exame>> GetAll() => await DbSet.ToListAsync();

        public async Task<Exame> GetById(Guid id) => await DbSet.FindAsync(id);
    }
}

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
    public class PacienteRepository : IPacienteRepository
    {
        protected readonly ShiftContext Context;
        protected readonly DbSet<Paciente> DbSet;

        public PacienteRepository(ShiftContext context)
        {
            Context = context;
            DbSet = Context.Set<Paciente>();
        }

        public IUnitOfWork UnitOfWork => Context;

        public void Dispose() => Context.Dispose();

        public async Task<IEnumerable<Paciente>> GetAll() => await DbSet.ToListAsync();

        public async Task<Paciente> GetById(Guid id) => await DbSet.FindAsync(id);
    }
}

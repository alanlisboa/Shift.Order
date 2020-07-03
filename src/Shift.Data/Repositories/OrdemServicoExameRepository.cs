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
    public class OrdemServicoExameRepository : IOrdemServicoExameRepository
    {
        protected readonly ShiftContext Context;
        protected readonly DbSet<OrdemServicoExame> DbSet;

        public OrdemServicoExameRepository(ShiftContext context)
        {
            Context = context;
            DbSet = Context.Set<OrdemServicoExame>();
        }

        public IUnitOfWork UnitOfWork => Context;
        
        public void Add(OrdemServicoExame ordemServicoExame) => DbSet.Add(ordemServicoExame);

        public void Dispose() => Context.Dispose();

        public async Task<IEnumerable<OrdemServicoExame>> GetAll(Guid ordemServicoId)
        {
            return await DbSet
                .Where(o => o.OrdemServicoId == ordemServicoId)
                .Include(o => o.Exame)
                .Include(o => o.OrdemServico)
                    .ToListAsync();
        }
        public async Task<OrdemServicoExame> GetById(Guid id)
        {
            return await DbSet
                .Include(o => o.Exame)
                .Include(o => o.OrdemServico)
                    .Where(o => o.Id == id)
                    .FirstOrDefaultAsync();
        }

        public void Remove(OrdemServicoExame ordemServicoExame) => DbSet.Remove(ordemServicoExame);

        public void Update(OrdemServicoExame ordemServicoExame) => DbSet.Update(ordemServicoExame);
    }
}

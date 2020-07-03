using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
    public class OrdemServicoRepository : IOrdemServicoRepository
    {
        protected readonly ShiftContext Context;
        protected readonly DbSet<OrdemServico> DbSet;

        public OrdemServicoRepository(ShiftContext context)
        {
            Context = context;
            DbSet = Context.Set<OrdemServico>();
        }

        public IUnitOfWork UnitOfWork => Context;

        public void Add(OrdemServico ordemServico) => DbSet.Add(ordemServico);

        public void Dispose() => Context.Dispose();

        public async Task<IEnumerable<OrdemServico>> GetAll()
        {
            return await DbSet
                .Include(o => o.Paciente)
                .Include(o => o.Convenio)
                .Include(o => o.Medico)
                .Include(o => o.PostoColeta)
                    .ToListAsync();
        }
        public async Task<OrdemServico> GetById(Guid id)
        {
            return await DbSet
                .Include(o => o.Paciente)
                .Include(o => o.Paciente.Endereco)
                .Include(o => o.Paciente.Endereco.Cidade)
                .Include(o => o.Paciente.Endereco.Cidade.Estado)
                .Include(o => o.Convenio)
                .Include(o => o.Medico)
                .Include(o => o.Medico.Especialidade)
                .Include(o => o.PostoColeta)
                .Include(o => o.Exames)
                .ThenInclude(o => o.Exame)
                    .Where(o => o.Id == id)
                    .FirstOrDefaultAsync();
        }

        public async Task<OrdemServico> GetByNumber(int number)
        {
            return await DbSet
                .Include(o => o.Paciente)
                .Include(o => o.Paciente.Endereco)
                .Include(o => o.Paciente.Endereco.Cidade)
                .Include(o => o.Paciente.Endereco.Cidade.Estado)
                .Include(o => o.Convenio)
                .Include(o => o.Medico)
                .Include(o => o.Medico.Especialidade)
                .Include(o => o.PostoColeta)
                .Include(o => o.Exames)
                .ThenInclude(o => o.Exame)
                    .Where(o => o.Numero == number)
                    .FirstOrDefaultAsync();
        }

        public async Task<int> GetLastNumber()
        {
            int lastNumber = 0;
            
            if (Context.OrdemServico.Count() > 0)
                 lastNumber = await DbSet
                    .Select(c => c.Numero).MaxAsync();

            return lastNumber;
        }

        public void Remove(OrdemServico ordemServico)
        {
            ordemServico.Exames.ToList().ForEach(e =>
                Context.OrdemServicoExame.Remove(e));

            DbSet.Remove(ordemServico);
        }
        public void Update(OrdemServico ordemServico) => DbSet.Update(ordemServico);
    }
}

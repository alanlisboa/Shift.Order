using Microsoft.EntityFrameworkCore;
using Shift.Domain.Models;
using Shift.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shift.Core.Data;
using System.Threading.Tasks;
using Shift.Core.Mediator;
using Shift.Core.Domain;
using Shift.Core.Messaging;
using FluentValidation.Results;
using Shift.Data.Mappings;
using Shift.Data.Extensions;

namespace Shift.Data.Contexts
{
    public class ShiftContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public ShiftContext(DbContextOptions<ShiftContext> options, IMediatorHandler mediatorHandler) : base(options)
        {
            _mediatorHandler = mediatorHandler;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Convenio> Convenio { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Exame> Exame { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<OrdemServico> OrdemServico { get; set; }
        public DbSet<OrdemServicoExame> OrdemServicoExame { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<PostoColeta> PostoColeta { get; set; }

        public async Task<bool> Commit()
        {
            await _mediatorHandler.PublishDomainEvents(this).ConfigureAwait(false);

            return await SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            cascadeFKs.ToList().ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);

            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();

            modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string))
                .ToList()
                .ForEach(property =>
                {
                    if (property.GetMaxLength() == null)
                        property.SetMaxLength(100);
                });

            modelBuilder.ApplyConfiguration(new CidadeMap());
            modelBuilder.ApplyConfiguration(new ConvenioMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new EspecialidadeMap());
            modelBuilder.ApplyConfiguration(new EstadoMap());
            modelBuilder.ApplyConfiguration(new ExameMap());
            modelBuilder.ApplyConfiguration(new MedicoMap());
            modelBuilder.ApplyConfiguration(new OrdemServicoExameMap());
            modelBuilder.ApplyConfiguration(new OrdemServicoMap());
            modelBuilder.ApplyConfiguration(new PacienteMap());
            modelBuilder.ApplyConfiguration(new PostoColetaMap());

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }

    public static class MediatorExtension
    {
        public static async Task PublishDomainEvents<T>(this IMediatorHandler mediator, T ctx) where T : DbContext
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents?.Any() == true);

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) => {
                    await mediator.PublishEvent(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}

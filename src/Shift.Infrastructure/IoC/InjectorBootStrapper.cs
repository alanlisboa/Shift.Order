using Shift.Domain.Commands;
using Shift.Domain.Core.Events;
using Shift.Domain.Events;
using Shift.Domain.Interfaces;
using Shift.Infrastructure.Bus;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shift.Core.Mediator;
using Shift.Domain.Events.Convenio;
using Shift.Domain.Commands.Convenio;
using Shift.Data.Contexts;
using Shift.Data.Repositories.EventSourcing;
using Shift.Data.Repositories;
using Shift.Data.EventSourcing;
using Shift.Application.Services;
using Shift.Domain.Events.OrdemServico;
using Shift.Domain.Commands.OrdemServico;
using Shift.Domain.Commands.OrdemServicoExame;
using Shift.Domain.Events.OrdemServicoExame;
using Shift.Application.Services.Interfaces;

namespace Shift.Infrastructure.IoC
{
    public static class InjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<IOrdemServicoAppService, OrdemServicoAppService>();
            services.AddScoped<IOrdemServicoExameAppService, OrdemServicoExameAppService>();
            services.AddScoped<IConvenioAppService, ConvenioAppService>();
            services.AddScoped<IMedicoAppService, MedicoAppService>();
            services.AddScoped<IPacienteAppService, PacienteAppService>();
            services.AddScoped<IPostoColetaAppService, PostoColetaAppService>();
            services.AddScoped<IExameAppService, ExameAppService>();

            // Domain Events
            services.AddScoped<INotificationHandler<OrdemServicoAddedEvent>, OrdemServicoEventHandler>();
            services.AddScoped<INotificationHandler<OrdemServicoUpdatedEvent>, OrdemServicoEventHandler>();
            services.AddScoped<INotificationHandler<OrdemServicoRemovedEvent>, OrdemServicoEventHandler>();

            services.AddScoped<INotificationHandler<OrdemServicoExameAddedEvent>, OrdemServicoExameEventHandler>();
            services.AddScoped<INotificationHandler<OrdemServicoExameUpdatedEvent>, OrdemServicoExameEventHandler>();
            services.AddScoped<INotificationHandler<OrdemServicoExameRemovedEvent>, OrdemServicoExameEventHandler>();

            services.AddScoped<INotificationHandler<ConvenioAddedEvent>, ConvenioEventHandler>();
            services.AddScoped<INotificationHandler<ConvenioUpdatedEvent>, ConvenioEventHandler>();
            services.AddScoped<INotificationHandler<ConvenioRemovedEvent>, ConvenioEventHandler>();
            
            // Domain Commands
            services.AddScoped<IRequestHandler<AddOrdemServicoCommand, ValidationResult>, OrdemServicoCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateOrdemServicoCommand, ValidationResult>, OrdemServicoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveOrdemServicoCommand, ValidationResult>, OrdemServicoCommandHandler>();

            services.AddScoped<IRequestHandler<AddOrdemServicoExameCommand, ValidationResult>, OrdemServicoExameCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateOrdemServicoExameCommand, ValidationResult>, OrdemServicoExameCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveOrdemServicoExameCommand, ValidationResult>, OrdemServicoExameCommandHandler>();

            services.AddScoped<IRequestHandler<AddConvenioCommand, ValidationResult>, ConvenioCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateConvenioCommand, ValidationResult>, ConvenioCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveConvenioCommand, ValidationResult>, ConvenioCommandHandler>();

            // Data
            services.AddScoped<IOrdemServicoRepository, OrdemServicoRepository>();
            services.AddScoped<IOrdemServicoExameRepository, OrdemServicoExameRepository>();
            services.AddScoped<IConvenioRepository, ConvenioRepository>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IPacienteRepository, PacienteRepository>();
            services.AddScoped<IPostoColetaRepository, PostoColetaRepository>();
            services.AddScoped<IExameRepository, ExameRepository>();

            services.AddScoped<ShiftContext>();

            // EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSqlContext>();
        }
    }
}
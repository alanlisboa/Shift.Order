using FluentValidation.Results;
using MediatR;
using Shift.Core.Messaging;
using Shift.Domain.Events.OrdemServico;
using Shift.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shift.Domain.Commands.OrdemServico
{
    public class OrdemServicoCommandHandler : CommandHandler, 
        IRequestHandler<AddOrdemServicoCommand, ValidationResult>,
        IRequestHandler<UpdateOrdemServicoCommand, ValidationResult>,
        IRequestHandler<RemoveOrdemServicoCommand, ValidationResult>
    {
        private readonly IOrdemServicoRepository _ordemServicoRepository;

        public OrdemServicoCommandHandler(IOrdemServicoRepository ordemServicoRepository)
        {
            _ordemServicoRepository = ordemServicoRepository;
        }

        // Add Command
        public async Task<ValidationResult> Handle(AddOrdemServicoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            var OrdemServico = new Models.OrdemServico(
                id: Guid.NewGuid(),
                numero: request.Numero,
                data: request.DataOrdem,
                pacienteId: request.PacienteId,
                convenioId: request.ConvenioId,
                postoId: request.PostoColetaId,
                medicoId: request.MedicoId); 

            if (await _ordemServicoRepository.GetByNumber(request.Numero) != null)
            {
                AddError("Já existe ordem de serviço com esse número");
                return ValidationResult;
            }

            OrdemServico.AddDomainEvent(new OrdemServicoAddedEvent(
                id: OrdemServico.Id,
                numero: OrdemServico.Numero,
                data: OrdemServico.DataOrdem,
                pacienteId: OrdemServico.PacienteId,
                convenioId: OrdemServico.ConvenioId,
                postoId: OrdemServico.PostoColetaId,
                medicoId: OrdemServico.MedicoId));

            _ordemServicoRepository.Add(OrdemServico);

            return await Commit(_ordemServicoRepository.UnitOfWork);
        }

        // Update Command
        public async Task<ValidationResult> Handle(UpdateOrdemServicoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            var OrdemServico = new Models.OrdemServico(
                id: request.Id,
                numero: request.Numero,
                data: request.DataOrdem,
                pacienteId: request.PacienteId,
                convenioId: request.ConvenioId,
                postoId: request.PostoColetaId,
                medicoId: request.MedicoId);

            var existing = await _ordemServicoRepository.GetByNumber(OrdemServico.Numero);

            if (existing != null && existing.Id != OrdemServico.Id)
            {
                AddError("Já existe ordem de serviço com esse número");
                return ValidationResult;
            }

            OrdemServico.AddDomainEvent(new OrdemServicoUpdatedEvent(
                id: OrdemServico.Id,
                numero: OrdemServico.Numero,
                data: OrdemServico.DataOrdem,
                pacienteId: OrdemServico.PacienteId,
                convenioId: OrdemServico.ConvenioId,
                postoId: OrdemServico.PostoColetaId,
                medicoId: OrdemServico.MedicoId));

            _ordemServicoRepository.Update(OrdemServico);

            return await Commit(_ordemServicoRepository.UnitOfWork);
        }

        // Remove Command
        public async Task<ValidationResult> Handle(RemoveOrdemServicoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            var OrdemServico = await _ordemServicoRepository.GetById(request.Id);

            if (OrdemServico is null)
            {
                AddError("Ordem de serviço não existe");
                return ValidationResult;
            }

            OrdemServico.AddDomainEvent(new OrdemServicoRemovedEvent(request.Id));

            _ordemServicoRepository.Remove(OrdemServico);

            return await Commit(_ordemServicoRepository.UnitOfWork);
        }
    }
}

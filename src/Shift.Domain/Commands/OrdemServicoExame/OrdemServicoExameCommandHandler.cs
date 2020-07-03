using FluentValidation.Results;
using MediatR;
using Shift.Core.Messaging;
using Shift.Domain.Events.OrdemServicoExame;
using Shift.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shift.Domain.Commands.OrdemServicoExame
{
    public class OrdemServicoExameCommandHandler : CommandHandler, 
        IRequestHandler<AddOrdemServicoExameCommand, ValidationResult>,
        IRequestHandler<UpdateOrdemServicoExameCommand, ValidationResult>,
        IRequestHandler<RemoveOrdemServicoExameCommand, ValidationResult>
    {
        private readonly IOrdemServicoExameRepository _OrdemServicoExameRepository;

        public OrdemServicoExameCommandHandler(IOrdemServicoExameRepository OrdemServicoExameRepository)
        {
            _OrdemServicoExameRepository = OrdemServicoExameRepository;
        }

        public async Task<ValidationResult> Handle(AddOrdemServicoExameCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            var OrdemServicoExame = new Models.OrdemServicoExame(
                id: Guid.NewGuid(),
                ordemId: request.OrdemServicoId,
                exameId: request.ExameId,
                valor: request.Valor);

            OrdemServicoExame.AddDomainEvent(new OrdemServicoExameAddedEvent(
                id: Guid.NewGuid(),
                ordemId: request.OrdemServicoId,
                exameId: request.ExameId,
                valor: request.Valor));

            _OrdemServicoExameRepository.Add(OrdemServicoExame);

            return await Commit(_OrdemServicoExameRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateOrdemServicoExameCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            var OrdemServicoExame = new Models.OrdemServicoExame(
                id: request.Id,
                ordemId: request.OrdemServicoId,
                exameId: request.ExameId,
                valor: request.Valor);

            OrdemServicoExame.AddDomainEvent(new OrdemServicoExameUpdatedEvent(
                id: request.Id,
                ordemId: request.OrdemServicoId,
                exameId: request.ExameId,
                valor: request.Valor));

            _OrdemServicoExameRepository.Update(OrdemServicoExame);

            return await Commit(_OrdemServicoExameRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveOrdemServicoExameCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            var OrdemServicoExame = await _OrdemServicoExameRepository.GetById(request.Id);

            if (OrdemServicoExame is null)
            {
                AddError("Item não existe");
                return ValidationResult;
            }

            OrdemServicoExame.AddDomainEvent(new OrdemServicoExameRemovedEvent(request.Id));

            _OrdemServicoExameRepository.Remove(OrdemServicoExame);

            return await Commit(_OrdemServicoExameRepository.UnitOfWork);
        }
    }
}

using FluentValidation.Results;
using MediatR;
using Shift.Core.Messaging;
using Shift.Domain.Events;
using Shift.Domain.Events.Convenio;
using Shift.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shift.Domain.Commands.Convenio
{
    public class ConvenioCommandHandler : CommandHandler, 
        IRequestHandler<AddConvenioCommand, ValidationResult>,
        IRequestHandler<UpdateConvenioCommand, ValidationResult>,
        IRequestHandler<RemoveConvenioCommand, ValidationResult>
    {
        private readonly IConvenioRepository _convenioRepository;

        public ConvenioCommandHandler(IConvenioRepository convenioRepository)
        {
            _convenioRepository = convenioRepository;
        }

        public async Task<ValidationResult> Handle(AddConvenioCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            var convenio = new Models.Convenio(Guid.NewGuid(), request.Nome);

            if (await _convenioRepository.GetByName(request.Nome) != null)
            {
                AddError("Já existe convênio com esse nome");
                return ValidationResult;
            }

            convenio.AddDomainEvent(new ConvenioAddedEvent(convenio.Id, convenio.Nome));

            _convenioRepository.Add(convenio);

            return await Commit(_convenioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateConvenioCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            var convenio = new Models.Convenio(request.Id, request.Nome);

            var existing = await _convenioRepository.GetByName(convenio.Nome);

            if (existing != null && existing.Id != convenio.Id)
            {
                AddError("Já existe convênio com esse nome.");
                return ValidationResult;
            }

            convenio.AddDomainEvent(new ConvenioUpdatedEvent(convenio.Id, convenio.Nome));

            _convenioRepository.Update(convenio);

            return await Commit(_convenioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveConvenioCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            var convenio = await _convenioRepository.GetById(request.Id);

            if (convenio is null)
            {
                AddError("Convênio não existe");
                return ValidationResult;
            }

            convenio.AddDomainEvent(new ConvenioRemovedEvent(request.Id));

            _convenioRepository.Remove(convenio);

            return await Commit(_convenioRepository.UnitOfWork);
        }
    }
}

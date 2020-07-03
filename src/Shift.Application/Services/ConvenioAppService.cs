using AutoMapper;
using FluentValidation.Results;
using Shift.Application.EventSourcedNormalizers;
using Shift.Application.Services.Interfaces;
using Shift.Application.ViewModels;
using Shift.Core.Mediator;
using Shift.Data.Repositories.EventSourcing;
using Shift.Domain.Commands.Convenio;
using Shift.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shift.Application.Services
{
    public class ConvenioAppService : IConvenioAppService
    {
        private readonly IMapper _mapper;
        private readonly IConvenioRepository _convenioRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public ConvenioAppService(IMapper mapper,
                                  IConvenioRepository convenioRepository,
                                  IMediatorHandler mediator,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _convenioRepository = convenioRepository;
            _mediator = mediator;
            _eventStoreRepository = eventStoreRepository;
        }

        public async Task<IEnumerable<ConvenioViewModel>> GetAll() =>
            _mapper.Map<IEnumerable<ConvenioViewModel>>(await _convenioRepository.GetAll());

        public async Task<ConvenioViewModel> GetById(Guid id) =>
            _mapper.Map<ConvenioViewModel>(await _convenioRepository.GetById(id));

        public async Task<ValidationResult> Add(ConvenioViewModel convenioViewModel)
        {
            var addCommand = _mapper.Map<AddConvenioCommand>(convenioViewModel);
            return await _mediator.SendCommand(addCommand);
        }

        public async Task<ValidationResult> Update(ConvenioViewModel convenioViewModel)
        {
            var updateCommand = _mapper.Map<UpdateConvenioCommand>(convenioViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var removeCommand = new RemoveConvenioCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public async Task<IList<ConvenioHistoryData>> GetAllHistory(Guid id) =>
            ConvenioHistory.ToListConvenioHistory(await _eventStoreRepository.All(id));

        public void Dispose() => GC.SuppressFinalize(this);
    }
}

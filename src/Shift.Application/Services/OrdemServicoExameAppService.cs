using AutoMapper;
using FluentValidation.Results;
using Shift.Application.Services.Interfaces;
using Shift.Application.ViewModels;
using Shift.Core.Mediator;
using Shift.Domain.Commands.OrdemServicoExame;
using Shift.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shift.Application.Services
{
    public class OrdemServicoExameAppService : IOrdemServicoExameAppService
    {
        private readonly IMapper _mapper;
        private readonly IOrdemServicoExameRepository _ordemServicoExameRepository;
        private readonly IMediatorHandler _mediator;

        public OrdemServicoExameAppService(IMapper mapper,
                                           IOrdemServicoExameRepository ordemServicoExameRepository,
                                           IMediatorHandler mediator)
        {
            _mapper = mapper;
            _ordemServicoExameRepository = ordemServicoExameRepository;
            _mediator = mediator;
        }

        public async Task<ValidationResult> Add(OrdemServicoExameViewModel ordemServicoExameViewModel)
        {
            var addCommand = _mapper.Map<AddOrdemServicoExameCommand>(ordemServicoExameViewModel);
            return await _mediator.SendCommand(addCommand);
        }

        public async Task<IEnumerable<OrdemServicoExameViewModel>> GetAll(Guid ordemServicoId) =>
            _mapper.Map<IEnumerable<OrdemServicoExameViewModel>>(await _ordemServicoExameRepository.GetAll(ordemServicoId));

        public async Task<OrdemServicoExameViewModel> GetById(Guid id) =>
            _mapper.Map<OrdemServicoExameViewModel>(await _ordemServicoExameRepository.GetById(id));

        public async Task<ValidationResult> Remove(Guid id)
        {
            var removeCommand = new RemoveOrdemServicoExameCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public async Task<ValidationResult> Update(OrdemServicoExameViewModel ordemServicoExameViewModel)
        {
            var updateCommand = _mapper.Map<UpdateOrdemServicoExameCommand>(ordemServicoExameViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public void Dispose() => GC.SuppressFinalize(this);
    }
}

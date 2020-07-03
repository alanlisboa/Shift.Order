using AutoMapper;
using FluentValidation.Results;
using Shift.Application.Services.Interfaces;
using Shift.Application.ViewModels;
using Shift.Core.Mediator;
using Shift.Domain.Commands.OrdemServico;
using Shift.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shift.Application.Services
{
    public class OrdemServicoAppService : IOrdemServicoAppService
    {
        private readonly IMapper _mapper;
        private readonly IOrdemServicoRepository _ordemServicoRepository;
        private readonly IMediatorHandler _mediator;

        public OrdemServicoAppService(IMapper mapper,
                                  IOrdemServicoRepository ordemServicoRepository,
                                  IMediatorHandler mediator)
        {
            _mapper = mapper;
            _ordemServicoRepository = ordemServicoRepository;
            _mediator = mediator;
        }

        public async Task<ValidationResult> Add(OrdemServicoViewModel ordemServicoViewModel)
        {
            var addCommand = _mapper.Map<AddOrdemServicoCommand>(ordemServicoViewModel);
            return await _mediator.SendCommand(addCommand);
        }

        public async Task<IEnumerable<OrdemServicoViewModel>> GetAll() =>
            _mapper.Map<IEnumerable<OrdemServicoViewModel>>(await _ordemServicoRepository.GetAll());

        public async Task<OrdemServicoViewModel> GetById(Guid id) =>
            _mapper.Map<OrdemServicoViewModel>(await _ordemServicoRepository.GetById(id));

        public async Task<OrdemServicoViewModel> GetByNumber(int number) =>
            _mapper.Map<OrdemServicoViewModel>(await _ordemServicoRepository.GetByNumber(number));

        public async Task<int> GetLastNumber() =>
            await _ordemServicoRepository.GetLastNumber();

        public async Task<ValidationResult> Remove(Guid id)
        {
            var removeCommand = new RemoveOrdemServicoCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public async Task<ValidationResult> Update(OrdemServicoViewModel ordemServicoViewModel)
        {
            var updateCommand = _mapper.Map<UpdateOrdemServicoCommand>(ordemServicoViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public void Dispose() => GC.SuppressFinalize(this);
    }
}

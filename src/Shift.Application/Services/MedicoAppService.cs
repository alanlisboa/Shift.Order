using AutoMapper;
using Shift.Application.Services.Interfaces;
using Shift.Application.ViewModels;
using Shift.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shift.Application.Services
{
    public class MedicoAppService : IMedicoAppService
    {
        private readonly IMapper _mapper;
        private readonly IMedicoRepository _medicoRepository;
        
        public MedicoAppService(IMapper mapper,
                                IMedicoRepository medicoRepository)
        {
            _mapper = mapper;
            _medicoRepository = medicoRepository;
        }

        public async Task<IEnumerable<MedicoViewModel>> GetAll() =>
            _mapper.Map<IEnumerable<MedicoViewModel>>(await _medicoRepository.GetAll());

        public async Task<MedicoViewModel> GetById(Guid id) =>
            _mapper.Map<MedicoViewModel>(await _medicoRepository.GetById(id));

        public void Dispose() => GC.SuppressFinalize(this);
    }
}

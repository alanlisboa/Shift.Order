using AutoMapper;
using Shift.Application.Services.Interfaces;
using Shift.Application.ViewModels;
using Shift.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shift.Application.Services
{
    public class PacienteAppService : IPacienteAppService
    {
        private readonly IMapper _mapper;
        private readonly IPacienteRepository _pacienteRepository;
        
        public PacienteAppService(IMapper mapper,
                                  IPacienteRepository pacienteRepository)
        {
            _mapper = mapper;
            _pacienteRepository = pacienteRepository;
        }

        public async Task<IEnumerable<PacienteViewModel>> GetAll() =>
            _mapper.Map<IEnumerable<PacienteViewModel>>(await _pacienteRepository.GetAll());

        public async Task<PacienteViewModel> GetById(Guid id) =>
            _mapper.Map<PacienteViewModel>(await _pacienteRepository.GetById(id));

        public void Dispose() => GC.SuppressFinalize(this);
    }
}

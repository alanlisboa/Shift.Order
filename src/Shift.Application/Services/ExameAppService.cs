using AutoMapper;
using Shift.Application.Services.Interfaces;
using Shift.Application.ViewModels;
using Shift.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shift.Application.Services
{
    public class ExameAppService : IExameAppService
    {
        private readonly IMapper _mapper;
        private readonly IExameRepository _exameRepository;
        
        public ExameAppService(IMapper mapper,
                               IExameRepository exameRepository)
        {
            _mapper = mapper;
            _exameRepository = exameRepository;
        }

        public async Task<IEnumerable<ExameViewModel>> GetAll() =>
            _mapper.Map<IEnumerable<ExameViewModel>>(await _exameRepository.GetAll());

        public async Task<ExameViewModel> GetById(Guid id) =>
            _mapper.Map<ExameViewModel>(await _exameRepository.GetById(id));

        public void Dispose() => GC.SuppressFinalize(this);
    }
}

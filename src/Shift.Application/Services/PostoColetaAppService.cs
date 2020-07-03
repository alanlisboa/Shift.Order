using AutoMapper;
using Shift.Application.Services.Interfaces;
using Shift.Application.ViewModels;
using Shift.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shift.Application.Services
{
    public class PostoColetaAppService : IPostoColetaAppService
    {
        private readonly IMapper _mapper;
        private readonly IPostoColetaRepository _postoColetaRepository;
        
        public PostoColetaAppService(IMapper mapper,
                                     IPostoColetaRepository postoColetaRepository)
        {
            _mapper = mapper;
            _postoColetaRepository = postoColetaRepository;
        }

        public async Task<IEnumerable<PostoColetaViewModel>> GetAll() =>
            _mapper.Map<IEnumerable<PostoColetaViewModel>>(await _postoColetaRepository.GetAll());

        public async Task<PostoColetaViewModel> GetById(Guid id) =>
            _mapper.Map<PostoColetaViewModel>(await _postoColetaRepository.GetById(id));

        public void Dispose() => GC.SuppressFinalize(this);
    }
}

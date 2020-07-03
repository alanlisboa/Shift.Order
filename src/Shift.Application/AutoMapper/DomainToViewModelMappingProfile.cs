using AutoMapper;
using Shift.Application.ViewModels;
using Shift.Domain.Models;

namespace Shift.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cidade, CidadeViewModel>();
            CreateMap<Convenio, ConvenioViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Especialidade, EspecialidadeViewModel>();
            CreateMap<Estado, EstadoViewModel>();
            CreateMap<Exame, ExameViewModel>();
            CreateMap<Medico, MedicoViewModel>();
            CreateMap<OrdemServico, OrdemServicoViewModel>();
            CreateMap<OrdemServicoExame, OrdemServicoExameViewModel>();
            CreateMap<Paciente, PacienteViewModel>();
            CreateMap<PostoColeta, PostoColetaViewModel>();
        }
    }
}

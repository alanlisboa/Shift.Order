using AutoMapper;
using Shift.Application.ViewModels;
using Shift.Domain.Commands.Convenio;
using Shift.Domain.Commands.OrdemServico;
using Shift.Domain.Commands.OrdemServicoExame;
using Shift.Domain.Models;

namespace Shift.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ConvenioViewModel, AddConvenioCommand>()
                .ConstructUsing(c => new AddConvenioCommand(c.Nome));

            CreateMap<ConvenioViewModel, UpdateConvenioCommand>()
                .ConstructUsing(c => new UpdateConvenioCommand(c.Id, c.Nome));

            CreateMap<OrdemServicoViewModel, AddOrdemServicoCommand>()
                .ConvertUsing(o => new AddOrdemServicoCommand(o.DataOrdem, o.Numero, o.Paciente.Id, o.Convenio.Id, o.PostoColeta.Id, o.Medico.Id));

            CreateMap<OrdemServicoViewModel, UpdateOrdemServicoCommand>()
                .ConvertUsing(o => new UpdateOrdemServicoCommand(o.Id, o.DataOrdem, o.Numero, o.Paciente.Id, o.Convenio.Id, o.PostoColeta.Id, o.Medico.Id));

            CreateMap<OrdemServicoExameViewModel, AddOrdemServicoExameCommand>()
                .ConvertUsing(i => new AddOrdemServicoExameCommand(i.OrdemServico.Id, i.Exame.Id, i.Valor));

            CreateMap<OrdemServicoExameViewModel, UpdateOrdemServicoExameCommand>()
                .ConvertUsing(i => new UpdateOrdemServicoExameCommand(i.Id, i.OrdemServico.Id, i.Exame.Id, i.Valor));
        }
    }
}

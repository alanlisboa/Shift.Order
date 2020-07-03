using Shift.Core.Domain;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shift.Application.ViewModels
{
    public class OrdemServicoExameViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Ordem de Serviço")]
        public OrdemServicoViewModel OrdemServico { get; set; }
        public ExameViewModel Exame { get; set; }

        public double Valor { get; set; }
    }
}

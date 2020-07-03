using Shift.Core.Domain;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shift.Application.ViewModels
{
    public class ExameViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Código ANS")]
        public string CodigoANS { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        public double Valor { get; set; }
    }
}

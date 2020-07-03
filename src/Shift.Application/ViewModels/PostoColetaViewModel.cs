using Shift.Core.Domain;
using System;
using System.ComponentModel;

namespace Shift.Application.ViewModels
{
    public class PostoColetaViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        public EnderecoViewModel Endereco { get; set; }
    }
}

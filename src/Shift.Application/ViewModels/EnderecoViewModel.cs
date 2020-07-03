using Shift.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift.Application.ViewModels
{
    public class EnderecoViewModel
    {
        public Guid Id { get; set; }
        public string Logradouro { get; protected set; }
        public int? Numero { get; protected set; }
        public string Complemento { get; protected set; }
        public string Bairro { get; protected set; }
        public string Cep { get; protected set; }
        public CidadeViewModel Cidade { get; protected set; }
    }
}

using Shift.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift.Domain.Models
{
    public class Endereco : Entity, IAggregateRoot
    {
        public Endereco(Guid id, string logradouro, int? numero, string complemento, string bairro, Guid cidadeId)
        {
            Id = id;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            CidadeId = cidadeId;
        }

        public Endereco()
        {
        }

        public string Logradouro { get; protected set; }
        public int? Numero { get; protected set; }
        public string Complemento { get; protected set; }
        public string Bairro { get; protected set; }
        public string Cep { get; protected set; }
        public Guid CidadeId { get; protected set; }
        public virtual Cidade Cidade { get; protected set; }
    }
}

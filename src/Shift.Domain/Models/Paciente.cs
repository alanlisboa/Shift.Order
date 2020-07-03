using Shift.Core.Domain;
using System;

namespace Shift.Domain.Models
{
    public class Paciente : Entity, IAggregateRoot
    {
        public Paciente(Guid id, string nome, string documento, DateTime dataNascimento, Sexo sexo, Guid enderecoId)
        {
            Id = id;
            Nome = nome;
            Documento = documento;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            EnderecoId = enderecoId;
        }

        public Paciente()
        {
        }

        public string Nome { get; private set; }
        public string Documento { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Sexo Sexo { get; private set; }
        public Guid EnderecoId { get; private set; }
        public virtual Endereco Endereco { get; private set; }
    }
}

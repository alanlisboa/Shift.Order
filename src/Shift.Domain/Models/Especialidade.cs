using Shift.Core.Domain;
using System;

namespace Shift.Domain.Models
{
    public class Especialidade : Entity, IAggregateRoot
    {
        public Especialidade(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Especialidade()
        {
        }

        public string Nome { get; private set; }
    }
}

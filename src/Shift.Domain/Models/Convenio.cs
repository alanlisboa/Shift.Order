using Shift.Core.Domain;
using System;

namespace Shift.Domain.Models
{
    public class Convenio : Entity, IAggregateRoot
    {
        public Convenio(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Convenio()
        {
        }

        public string Nome { get; private set; }
    }
}

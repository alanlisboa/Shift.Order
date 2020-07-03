using Shift.Core.Domain;
using System;

namespace Shift.Domain.Models
{
    public class Cidade : Entity, IAggregateRoot
    {
        public Cidade(Guid id, string nome, string ibge, Guid estadoId)
        {
            Id = id;
            Nome = nome;
            IBGE = ibge;
            EstadoId = estadoId;
        }

        public Cidade()
        {
        }

        public string Nome { get; private set; }
        public string IBGE { get; private set; }
        public Guid EstadoId { get; private set; }
        public virtual Estado Estado { get; private set; }
    }
}

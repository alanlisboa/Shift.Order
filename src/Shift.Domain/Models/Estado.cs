using Shift.Core.Domain;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Shift.Domain.Models
{
    public class Estado : Entity, IAggregateRoot
    {
        public Estado(Guid id, string nome, string ibge)
        {
            Id = id;
            Nome = nome;
            IBGE = ibge;
        }

        public Estado()
        {
        }

        public string Nome { get; set; }
        public string IBGE { get; set; }

        public virtual ICollection<Cidade> Cidades { get; set; }
    }
}

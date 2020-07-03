using Shift.Core.Domain;
using System;

namespace Shift.Domain.Models
{
    public class PostoColeta : Entity, IAggregateRoot
    {
        public PostoColeta(Guid id, string descricao, Guid enderecoId)
        {
            Id = id;
            Descricao = descricao;
            EnderecoId = enderecoId;
        }

        public PostoColeta()
        {
        }

        public string Descricao { get; private set; }
        public Guid EnderecoId { get; private set; }
        public virtual Endereco Endereco { get; private set; }
    }
}

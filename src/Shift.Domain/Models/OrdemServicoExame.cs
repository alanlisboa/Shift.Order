using Shift.Core.Domain;
using System;

namespace Shift.Domain.Models
{
    public class OrdemServicoExame : Entity, IAggregateRoot
    {
        public OrdemServicoExame(Guid id, Guid ordemId, Guid exameId, double valor)
        {
            Id = id;
            OrdemServicoId = ordemId;
            ExameId = exameId;
            Valor = valor;
        }

        public OrdemServicoExame()
        {
        }

        public Guid OrdemServicoId { get; set; }
        public virtual OrdemServico OrdemServico { get; set; }
        public Guid ExameId { get; set; }
        public virtual Exame Exame { get; set; }
        public double Valor { get; set; }
    }
}

using Shift.Core.Domain;
using System;

namespace Shift.Domain.Models
{
    public class Exame: Entity, IAggregateRoot
    {
        public Exame(Guid id, string codigoANS, string descricao, double valor)
        {
            Id = id;
            CodigoANS = codigoANS;
            Descricao = descricao;
            Valor = valor;
        }

        public Exame()
        {
        }

        public string CodigoANS { get; private set; }
        public string Descricao { get; private set; }
        public double Valor { get; private set; }
    }
}

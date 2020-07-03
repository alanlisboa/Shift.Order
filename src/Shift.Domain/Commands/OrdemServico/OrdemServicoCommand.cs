using Shift.Core.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift.Domain.Commands.OrdemServico
{
    public abstract class OrdemServicoCommand : Command
    {
        public Guid Id { get; protected set; }
        public int Numero { get; protected set; }
        public DateTime DataOrdem { get; protected set; }
        public Guid PacienteId { get; protected set; }
        public Guid ConvenioId { get; protected set; }
        public Guid PostoColetaId { get; protected set; }
        public Guid MedicoId { get; protected set; }
    }
}

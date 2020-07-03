using FluentValidation.Internal;
using Shift.Core.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift.Domain.Commands.OrdemServicoExame
{
    public abstract class OrdemServicoExameCommand : Command
    {
        public Guid Id { get; set; }
        public Guid OrdemServicoId { get; set; }
        public Guid ExameId { get; set; }
        public double Valor { get; set; }
    }
}

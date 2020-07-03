using Shift.Core.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift.Domain.Commands.Convenio
{
    public abstract class ConvenioCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
    }
}

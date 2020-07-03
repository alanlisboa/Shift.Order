using Shift.Core.Domain;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Shift.Application.ViewModels
{
    public class EstadoViewModel 
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string IBGE { get; set; }
    }
}

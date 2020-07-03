using Shift.Core.Domain;
using System;

namespace Shift.Application.ViewModels
{
    public class CidadeViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string IBGE { get; set; }
        public virtual EstadoViewModel Estado { get; set; }
    }
}

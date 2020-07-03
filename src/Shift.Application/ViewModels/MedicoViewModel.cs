using Shift.Core.Domain;
using System;

namespace Shift.Application.ViewModels
{
    public class MedicoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CRM { get; set; }
        public virtual EspecialidadeViewModel Especialidade { get; set; }
    }
}

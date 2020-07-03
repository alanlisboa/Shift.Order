using Shift.Core.Domain;
using System;

namespace Shift.Domain.Models
{
    public class Medico : Entity, IAggregateRoot
    {
        public Medico(Guid id, string nome, string crm, Guid especialidadeId)
        {
            Id = id;
            Nome = nome;
            CRM = crm;
            EspecialidadeId = especialidadeId;
        }

        public Medico()
        {
        }

        public string Nome { get; set; }
        public string CRM { get; set; }
        public Guid EspecialidadeId { get; set; }
        public virtual Especialidade Especialidade { get; set; }
    }
}

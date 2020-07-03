using Shift.Domain.Validators.Convenio;
using System;

namespace Shift.Domain.Commands.Convenio
{
    public class UpdateConvenioCommand : ConvenioCommand
    {
        public UpdateConvenioCommand(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateConvenioCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

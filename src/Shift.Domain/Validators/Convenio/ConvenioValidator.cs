using FluentValidation;
using Shift.Domain.Commands.Convenio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Shift.Domain.Validators.Convenio
{
    public abstract class ConvenioValidator<T>: AbstractValidator<T> where T : ConvenioCommand
    {
        protected void ValidateNome() => RuleFor(c => c.Nome)
            .NotEmpty().WithMessage("Por favor, verifique se você digitou o nome")
            .Length(2, 100).WithMessage("O campo nome deve ter entre 2 e 100 caracteres");

        protected void ValidateId() => RuleFor(c => c.Id)
            .NotEqual(Guid.Empty);
    }
}
